
using System.Collections.Generic;
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class EnemySpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private GameData _gameData;
        private CharacterData[] _enemiesData;
        private List<CharacterData> _selectedEnemies;
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<FollowComponent> _followPool;
        private int _bottomLvlDifference = 2;
        private int _upperLvlDifference = 1;
        private float _spawnTime = 5f;
        private float _spawnTimer;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameData = systems.GetShared<GameData>();
            _enemiesData = _gameData.EnemiesData.Enemies;
            _movePool = _world.GetPool<MoveComponent>();
            _followPool = _world.GetPool<FollowComponent>();
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
            ref var moveComponent = ref _movePool.Add(newEnemy);
            ref var followComponent = ref _followPool.Add(newEnemy);
            
            CreateEnemy(ref moveComponent, ref followComponent, enemyData);
        }

        private void CreateEnemy(
                                 ref MoveComponent moveComponentEnemy, 
                                 ref FollowComponent followComponentEnemy, 
                                 CharacterData enemyData
                                 )
        {
            var spawnedEnemy = GameObject.Instantiate(enemyData.CharacterPrefab);
            var rigidbody = spawnedEnemy.AddComponent<Rigidbody>();
            moveComponentEnemy.MovementSpeed = enemyData.MovementSpeed;
            moveComponentEnemy.Transform = spawnedEnemy.transform;
            moveComponentEnemy.Rigidbody = rigidbody;
            ref var moveComponentPlayer = ref _movePool.Get(_gameData.PlayerData.Entity);
            followComponentEnemy.TargetTransform = moveComponentPlayer.Transform;
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
            return _gameData.PlayerData.Level <= characterData.Level + _bottomLvlDifference;
        }
        
        private bool IsCorrectUpperLvl(CharacterData characterData)
        {
            return _gameData.PlayerData.Level >= characterData.Level - _upperLvlDifference;
        }

    }
}