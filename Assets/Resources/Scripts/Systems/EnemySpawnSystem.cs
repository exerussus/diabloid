
using System.Collections.Generic;
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using Resources.Scripts.Logic;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class EnemySpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private GameData _gameData;
        private CharacterData[] _enemiesData;
        private List<CharacterData> _selectedEnemies;
        private EcsPool<EnemyComponent> _enemyPool;
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<MovementInputComponent> _movementInputPool;
        private EcsPool<ClassComponent> _classPool;
        private EcsPool<ParametersComponent> _parametersPool;
        private EcsPool<CharacterResourceComponent> _characterResourcePool;
        private int _bottomLvlDifference = 2;
        private int _upperLvlDifference = 1;
        private float _spawnTime = 5f;
        private float _spawnTimer;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameData = systems.GetShared<GameData>();
            _enemiesData = _gameData.EnemiesData.Enemies;
            _enemyPool = _world.GetPool<EnemyComponent>();
            _movePool = _world.GetPool<MoveComponent>();
            _movementInputPool = _world.GetPool<MovementInputComponent>();
            _classPool = _world.GetPool<ClassComponent>();
            _parametersPool = _world.GetPool<ParametersComponent>();
            _characterResourcePool = _world.GetPool<CharacterResourceComponent>();
            SelectEnemiesWithCurrentLvl();
        }
        
        public void Run(IEcsSystems systems)
        {
            if (IsItTime()) Spawn(GetRandomEnemy());
        }
        
        private CharacterData GetRandomEnemy()
        {
            return _selectedEnemies[Random.Range(0, _selectedEnemies.Count)];
        }
        
        private void Spawn(CharacterData enemyData)
        {
            if (_enemiesData.Length == 0) return;
            var newEnemy = _world.NewEntity();
            
            _enemyPool.Add(newEnemy);
            _movementInputPool.Add(newEnemy);
            ref var moveComponent = ref _movePool.Add(newEnemy);
            ref var classComponent = ref _classPool.Add(newEnemy);
            ref var parametersComponent = ref _parametersPool.Add(newEnemy);
            ref var characterResourceComponent = ref _characterResourcePool.Add(newEnemy);
            
            CharacterCreator.CreateCharacter(
                enemyData, 
                ref moveComponent, 
                ref classComponent, 
                ref parametersComponent,
                ref characterResourceComponent,
                GetRandomPosition());
        }

        private void SelectEnemiesWithCurrentLvl()
        {
            if (_enemiesData.Length == 0) return;
            _selectedEnemies = new List<CharacterData>();
            
            foreach (var enemy in _enemiesData)
            {
                if (IsCorrectBottomLvl(enemy) && IsCorrectUpperLvl(enemy))
                {
                    _selectedEnemies.Add(enemy);
                }
            }
        }

        private Transform GetRandomPosition()
        {
            var spawners = _gameData.CurrentWorldInfo.EnemySpawners;
            return spawners[Random.Range(0, spawners.Length)];
        }
        
        private bool IsItTime()
        {
            if (_spawnTimer >= _spawnTime)
            {
                _spawnTimer = 0f;
                return true;
            }
            else
            {
                {
                    _spawnTimer += Time.fixedDeltaTime;
                    return false;
                }
            }
        }
        
        private bool IsCorrectBottomLvl(CharacterData characterData)
        {
            return _gameData.PlayerData.CharacterData.Level <= characterData.Level + _bottomLvlDifference;
        }
        
        private bool IsCorrectUpperLvl(CharacterData characterData)
        {
            return _gameData.PlayerData.CharacterData.Level >= characterData.Level - _upperLvlDifference;
        }

    }
}