using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class EnemyWeaponInputSystem : EcsSystemForeach
    {
        private EcsPool<WeaponInputComponent> _weaponInputPool;
        private EcsPool<WeaponComponent> _weaponPool;
        private EcsPool<MoveComponent> _movePool;
        private bool _isPressed;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<WeaponInputComponent>().Inc<EnemyComponent>().Inc<WeaponComponent>().Inc<MoveComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _weaponInputPool = _world.GetPool<WeaponInputComponent>();
            _weaponPool = _world.GetPool<WeaponComponent>();
            _movePool = _world.GetPool<MoveComponent>();
        }

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            var playerEntity = systems.GetShared<GameData>().PlayerData.Entity;
            ref var weaponInputComponent = ref _weaponInputPool.Get(entity);
            ref var weaponComponent = ref _weaponPool.Get(entity);
            ref var moveComponentEnemy = ref _movePool.Get(entity);
            ref var moveComponentPlayer = ref _movePool.Get(playerEntity);
            var distance = Vector3.Distance(moveComponentEnemy.Transform.position, moveComponentPlayer.Transform.position);
            if (distance <= weaponComponent.Range) weaponInputComponent.IsAttack = true;
        }
    }
}