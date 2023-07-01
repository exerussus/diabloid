
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using Resources.Scripts.Tools;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private GameData _gameData;
        private PlayerData _playerData;
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameData = systems.GetShared<GameData>();
            _playerData = _gameData.PlayerData;
            
            var player = _world.NewEntity();
            _playerData.Entity = player;
            
            var movePool = _world.GetPool<MoveComponent>();
            var inputEventPool = _world.GetPool<PlayerInputComponent>();
            
            inputEventPool.Add(player);
            ref var moveComponent = ref movePool.Add(player);
            
            CreatePlayer(ref moveComponent);
        }

        private void CreatePlayer(ref MoveComponent moveComponent)
        {
            var spawnedPlayerPrefab = GameObject.Instantiate(_playerData.CharacterPrefab);
            var rigidbody = spawnedPlayerPrefab.AddComponent<Rigidbody>();
            RigidbodyPreset.SetDefaultSettings(rigidbody, 60);
            moveComponent.Rigidbody = rigidbody;
            moveComponent.MovementSpeed = _playerData.MovementSpeed;
            moveComponent.Transform = spawnedPlayerPrefab.transform;
            _gameData.CinemachineVirtualCamera.LookAt = moveComponent.Transform;
            _gameData.CinemachineVirtualCamera.Follow = moveComponent.Transform;
        }
    }
}