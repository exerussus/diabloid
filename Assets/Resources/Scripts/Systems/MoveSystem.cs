
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Tools;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class MoveSystem : EcsSystemForeach
    {
        private int _multiply = 3;
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<MovementInputComponent> _movementInputPool;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<MoveComponent>().Inc<MovementInputComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _movePool = _world.GetPool<MoveComponent>();
            _movementInputPool = _world.GetPool<MovementInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems) {}

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            ref var moveComponent = ref _movePool.Get(entity);
            ref var movementInputComponent = ref _movementInputPool.Get(entity);
            var force = movementInputComponent.Direction * (moveComponent.MovementSpeed * _multiply);
            moveComponent.Rigidbody.velocity = force;
        }
    }
}