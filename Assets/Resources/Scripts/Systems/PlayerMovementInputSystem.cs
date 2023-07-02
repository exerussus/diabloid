
using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerMovementInputSystem : EcsSystemForeachExtended
    {
        private EcsPool<MovementInputComponent> _movementInputPool;
        private float _horizontalAxis;
        private float _verticalAxis;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<MovementInputComponent>().Inc<PlayerComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _movementInputPool = _world.GetPool<MovementInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems)
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");
        }

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            ref var movementInputComponent = ref _movementInputPool.Get(entity);
            movementInputComponent.Direction = new Vector3(_horizontalAxis, 0, _verticalAxis).normalized;
        }
    }
}