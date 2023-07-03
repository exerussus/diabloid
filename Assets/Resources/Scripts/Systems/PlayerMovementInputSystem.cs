
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

        protected override EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world)
        {
            return world.Filter<MovementInputComponent>().Inc<PlayerComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            _movementInputPool = world.GetPool<MovementInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");
        }

        protected override void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter)
        {
            ref var movementInputComponent = ref _movementInputPool.Get(entity);
            movementInputComponent.Direction = new Vector3(_horizontalAxis, 0, _verticalAxis).normalized;
        }
    }
}