
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<PlayerInputComponent> _playerInputPool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<PlayerInputComponent>().End();
            _playerInputPool = _world.GetPool<PlayerInputComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            foreach (var entity in _filter)
            {
                ref var playerInputComponent = ref _playerInputPool.Get(entity);
                playerInputComponent.Direction = new Vector2(x, y);
            }
        }
    }
}