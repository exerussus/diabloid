using Leopotam.EcsLite;
using Resources.Scripts.Data;
using Resources.Scripts.MonoBehaviours;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class WorldInitSystem : IEcsInitSystem
    {
        private GameData _gameData;
        
        public void Init(IEcsSystems systems)
        {
            _gameData = systems.GetShared<GameData>();
            _gameData.CurrentWorld = GameObject.Instantiate(_gameData.WorldsData[_gameData.CurrentWorldIndex].WorldPrefab);
            _gameData.CurrentWorldInfo = _gameData.CurrentWorld.GetComponent<WorldInfo>();
        }
    }
}