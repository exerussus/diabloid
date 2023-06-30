
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Tools;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class FollowSystem : EcsSystemForeach
    {
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<FollowComponent> _followPool;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<MoveComponent>().Inc<FollowComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _movePool = _world.GetPool<MoveComponent>();
            _followPool = _world.GetPool<FollowComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems) {}

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            ref var followComponent = ref _followPool.Get(entity);
            ref var moveComponent = ref _movePool.Get(entity);
            var position = moveComponent.Transform.position;
            Vector3 direction = (followComponent.TargetTransform.position - position).normalized;
            Vector3 newPosition = position + direction * (moveComponent.MovementSpeed * Time.deltaTime);
            position = newPosition;
            moveComponent.Transform.position = position;
        }
    }
}