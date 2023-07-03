
using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;

namespace Resources.Scripts.Systems
{
    public class MoveSystem : EcsSystemForeach
    {
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<MovementInputComponent> _movementInputPool;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world)
        {
            return world.Filter<MoveComponent>().Inc<MovementInputComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            _movePool = world.GetPool<MoveComponent>();
            _movementInputPool = world.GetPool<MovementInputComponent>();
        }

        protected override void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter)
        {
            ref var moveComponent = ref _movePool.Get(entity);
            ref var movementInputComponent = ref _movementInputPool.Get(entity);
            var velocity = movementInputComponent.Direction * moveComponent.MovementSpeed;
            moveComponent.Rigidbody.velocity = velocity;
        }
    }
}