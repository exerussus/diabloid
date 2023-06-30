
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Tools;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerInputSystem : EcsSystemForeach
    {
        private EcsPool<PlayerInputComponent> _playerInputPool;
        private float _horizontalAxis;
        private float _verticalAxis;

        protected override EcsWorld GetEcsWorld(IEcsSystems systems)
        {
            return systems.GetWorld();
        }

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<PlayerInputComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _playerInputPool = _world.GetPool<PlayerInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems)
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");
        }

        protected override void Foreach(IEcsSystems systems, int entity)
        {
            ref var playerInputComponent = ref _playerInputPool.Get(entity);
            playerInputComponent.Direction = new Vector2(_horizontalAxis, _verticalAxis);
        }
    }
}