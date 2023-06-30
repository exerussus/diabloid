
using System.Collections.Generic;
using Leopotam.EcsLite;
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
        private int _bottomLvlDifference = 2;
        private int _upperLvlDifference = 1;
        private float _spawnTime = 5f;
        private float _spawnTimer;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameData = systems.GetShared<GameData>();
            _enemiesData = _gameData._enemiesData.Enemies;
            SelectEnemiesWithCurrentLvl();
        }

        private CharacterData GetRandomEnemy()
        {
            return _selectedEnemies[Random.Range(0, _selectedEnemies.Count)];
        }
        
        private void Spawn(CharacterData enemyData)
        {
            // GameObject.Instantiate();
        }
        
        private void SelectEnemiesWithCurrentLvl()
        {
            _selectedEnemies.Clear();
            
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
        
        public void Run(IEcsSystems systems)
        {
            if (IsItTime()) Spawn(GetRandomEnemy());
        }
    }
}