using Leopotam.EcsLite;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class WorldInitSystem : IEcsInitSystem
    {
        private GameData _gameData;
        
        public void Init(IEcsSystems systems)
        {
            _gameData = systems.GetShared<GameData>();
            GameObject.Instantiate(_gameData.WorldData.WorldPrefab);
        }
    }
}