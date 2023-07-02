using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerWeaponInputSystem : EcsSystemForeachExtended
    {
        private EcsPool<WeaponInputComponent> _weaponInputPool;
        private bool _isPressed;

        protected override EcsFilter GetEcsFilter(IEcsSystems systems)
        {
            return _world.Filter<WeaponInputComponent>().Inc<PlayerComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems)
        {
            _weaponInputPool = _world.GetPool<WeaponInputComponent>();
        }

        protected override void BeforeForeach(IEcsSystems systems)
        {
            _isPressed = Input.GetMouseButtonDown(0);
        }

        protected override void InForeach(IEcsSystems systems, int entity)
        {
            ref var weaponInputComponent = ref _weaponInputPool.Get(entity);
            if (_isPressed) weaponInputComponent.IsAttack = true;
        }
    }
}