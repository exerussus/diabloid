using Leopotam.EcsLite;
using Resources.Scripts.Components;

namespace Resources.Scripts.Systems
{
    public class ParametersSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<ClassComponent> _classPool;
        private EcsPool<ParametersComponent> _parametersPool;
        
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ClassComponent>().Inc<ParametersComponent>().End();
            _classPool = _world.GetPool<ClassComponent>();
            _parametersPool = _world.GetPool<ParametersComponent>();

            foreach (var entity in _filter)
            {
                var classComponent = _classPool.Get(entity);
                var parametersComponent = _parametersPool.Get(entity);
                SetParameters(ref classComponent, ref parametersComponent);
            }
        }

        private void SetParameters(ref ClassComponent classComponent, ref ParametersComponent parametersComponent)
        {
            parametersComponent.Health = classComponent.Constitution * 3 + classComponent.Strength;
            parametersComponent.Stamina = classComponent.Agility * 3;
            parametersComponent.Mana = classComponent.Wisdom * 2;
            parametersComponent.PhysicalDamage = classComponent.Strength + classComponent.Agility;
            parametersComponent.MagicalDamage = classComponent.Wisdom * 1.5f;
            parametersComponent.PhysicalArmor = classComponent.Agility;
            parametersComponent.MagicalArmor = classComponent.Wisdom + classComponent.Agility;
            parametersComponent.MovementSpeed = 2 + classComponent.Agility * 0.1f;
        }
    }
}