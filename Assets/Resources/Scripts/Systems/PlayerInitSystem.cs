
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using Resources.Scripts.Logic;

namespace Resources.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private GameData _gameData;
        private PlayerData _playerData;
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<MovementInputComponent> _playerInputPool;
        private EcsPool<ClassComponent> _classPool;
        private EcsPool<ParametersComponent> _parametersPool;
        private EcsPool<PlayerComponent> _playerPool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameData = systems.GetShared<GameData>();
            _playerData = _gameData.PlayerData;
            
            var playerEntity = _world.NewEntity();
            _playerData.Entity = playerEntity;

            SetAllPools();
            
            _playerInputPool.Add(playerEntity);
            _playerPool.Add(playerEntity);
            ref var moveComponent = ref _movePool.Add(playerEntity);
            ref var classComponent = ref _classPool.Add(playerEntity);
            ref var parametersComponent = ref _parametersPool.Add(playerEntity);

            CharacterCreator.CreateCharacter(
                _gameData.PlayerData.CharacterData,
                ref moveComponent,
                ref classComponent,
                ref parametersComponent,
                _gameData.CurrentWorldInfo.PlayerSpawner);
            
            SetCamera(ref moveComponent);
        }

        private void SetAllPools()
        {
            _movePool = _world.GetPool<MoveComponent>();
            _playerInputPool = _world.GetPool<MovementInputComponent>();
            _classPool = _world.GetPool<ClassComponent>();
            _parametersPool = _world.GetPool<ParametersComponent>();
            _playerPool = _world.GetPool<PlayerComponent>();
        }
        
        private void SetCamera(ref MoveComponent moveComponent)
        {
            _gameData.CinemachineVirtualCamera.LookAt = moveComponent.Transform;
            _gameData.CinemachineVirtualCamera.Follow = moveComponent.Transform;
        }
    }
}