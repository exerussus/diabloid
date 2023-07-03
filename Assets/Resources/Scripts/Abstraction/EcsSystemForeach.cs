
using Leopotam.EcsLite;

namespace Resources.Scripts.Abstraction
{
    public abstract class EcsSystemForeach : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            world = systems.GetWorld();
            _filter = GetEcsFilter(systems, world);
            Initialization(systems, world, _filter);
        }
        
        public void Run(IEcsSystems systems)
        {

            foreach (var entity in _filter)
            {
                InForeach(systems, entity, world, _filter);
            }
        }
        
        protected abstract EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world);
        protected abstract void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter);
        protected abstract void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter);
    }
}