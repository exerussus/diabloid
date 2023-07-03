using Leopotam.EcsLite;
using Resources.Scripts.Abstraction;
using Resources.Scripts.Components;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    
    public class ResourcesRegenerationSystem : EcsSystemForeachIf
    {
        private float _healthRegenerationMultiply = 1f;
        private float _staminaRegenerationMultiply = 5f;
        private float _manaRegenerationMultiply = 1f;
        private float _tickTime = 1f;
        private float _tickTimer;
        private EcsPool<CharacterResourceComponent> _characterResourcePool;
        private EcsPool<ParametersComponent> _parametersPool;
        
        protected override EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world)
        {
            return world.Filter<CharacterResourceComponent>().Inc<ParametersComponent>().End();
        }

        protected override void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            _characterResourcePool = world.GetPool<CharacterResourceComponent>();
            _parametersPool = world.GetPool<ParametersComponent>();
        }

        protected override bool IsSuccessfully(IEcsSystems systems, EcsWorld world, EcsFilter filter)
        {
            if (_tickTimer >= _tickTime)
            {
                _tickTimer = 0f;
                return true;
            }
            else
            {
                _tickTimer += Time.fixedDeltaTime;
                return false;
            }
        }

        protected override void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter)
        {
            ref var characterResourceComponent = ref _characterResourcePool.Get(entity);
            ref var parametersComponent = ref _parametersPool.Get(entity);

            Regenerate(ref characterResourceComponent.Health, ref parametersComponent.Health, _healthRegenerationMultiply);
            Regenerate(ref characterResourceComponent.Stamina, ref parametersComponent.Stamina, _staminaRegenerationMultiply);
            Regenerate(ref characterResourceComponent.Mana, ref parametersComponent.Mana, _manaRegenerationMultiply);
        }

        private void Regenerate(ref float resource, ref float parameter, float regenerationMultiply)
        {
            if (!(resource < parameter)) return;
            resource += parameter / 50f * regenerationMultiply;
            if (resource > parameter)
                resource = parameter;
        }
    }
}