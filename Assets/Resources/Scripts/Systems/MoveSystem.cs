﻿
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Tools;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class MoveSystem : EcsSystemForeach
    {
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<PlayerInputComponent> _playerInputPool;

        protected override EcsWorld GetEcsWorld(IEcsSystems systems)
        {
            return systems.GetWorld();
        }

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<MoveComponent>().Inc<PlayerInputComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _movePool = _world.GetPool<MoveComponent>();
            _playerInputPool = _world.GetPool<PlayerInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems) {}

        protected override void Foreach(IEcsSystems systems, int entity)
        {
            ref var moveComponent = ref _movePool.Get(entity);
            ref var playerInputComponent = ref _playerInputPool.Get(entity);

            moveComponent.Transform.position += (Vector3)playerInputComponent.Direction 
                                                * (Time.deltaTime * moveComponent.MovementSpeed);
        }
    }
}