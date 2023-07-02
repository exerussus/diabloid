using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class WeaponAttackSystem : EcsSystemForeach
    {
        private EcsPool<MoveComponent> _movePool;
        private EcsPool<WeaponComponent> _weaponPool;
        private EcsPool<WeaponInputComponent> _weaponInputPool;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<WeaponComponent>().Inc<WeaponInputComponent>().Inc<MoveComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _movePool = _world.GetPool<MoveComponent>();
            _weaponPool = _world.GetPool<WeaponComponent>();
            _weaponInputPool = _world.GetPool<WeaponInputComponent>();
        }

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            ref var weaponComponent = ref _weaponPool.Get(entity);
            ref var weaponInputComponent = ref _weaponInputPool.Get(entity);
            
            if (weaponInputComponent.IsAttack && weaponComponent.IsReady)
            {
                ref var moveComponent = ref _movePool.Get(entity);
                
                weaponComponent.CoolDownTimer = 0f;
                weaponComponent.Weapon.Attack(moveComponent.Transform);
                weaponInputComponent.IsAttack = false;
            }
            else if (!weaponComponent.IsReady)
            {
                weaponInputComponent.IsAttack = false;
                weaponComponent.CoolDownTimer += Time.fixedDeltaTime;
            }
        }
    }
}