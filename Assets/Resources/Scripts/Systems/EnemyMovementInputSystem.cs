
using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class EnemyMovementInputSystem : EcsSystemForeach
    {
        private GameData _gameData;
        private Transform _playerTransform;
        private EcsPool<MovementInputComponent> _movementInputPool;
        private EcsPool<MoveComponent> _movePool;
        private float _minDistance = 2f;
        
        protected override EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world)
        {
            return world.Filter<MovementInputComponent>().Inc<EnemyComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            _movePool = world.GetPool<MoveComponent>();
            _movementInputPool = world.GetPool<MovementInputComponent>();
            _gameData = systems.GetShared<GameData>();
            _playerTransform = _movePool.Get(_gameData.PlayerData.Entity).Transform;
        }

        protected override void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter)
        {
            ref var moveComponent = ref _movePool.Get(entity);
            ref var movementInputPool = ref _movementInputPool.Get(entity);
            var playerTransformPosition = _playerTransform.position;
            var enemyTransformPosition = moveComponent.Transform.position;
            var distance = Vector3.Distance(playerTransformPosition, enemyTransformPosition);
            if (distance > _minDistance)
            {
                var dir = (playerTransformPosition - enemyTransformPosition).normalized;
                movementInputPool.Direction = new Vector3(dir.x, 0, dir.z);
            }
            else
            {
                movementInputPool.Direction = new Vector3();
            }
        }
    }
}