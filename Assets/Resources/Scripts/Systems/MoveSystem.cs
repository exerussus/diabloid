
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class MoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<PlayerInputComponent> _playerInputPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<MoveComponent>().Inc<PlayerInputComponent>().End();
            _movePool = _world.GetPool<MoveComponent>();
            _playerInputPool = _world.GetPool<PlayerInputComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _movePool.Get(entity);
                ref var playerInputComponent = ref _playerInputPool.Get(entity);

                moveComponent.Transform.position += (Vector3)playerInputComponent.Direction 
                                                    * (Time.deltaTime * moveComponent.MovementSpeed);
            }
        }
    }
}