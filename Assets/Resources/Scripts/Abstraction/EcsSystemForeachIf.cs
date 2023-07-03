using Leopotam.EcsLite;

namespace Resources.Scripts.Abstraction
{
    public abstract class EcsSystemForeachIf : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = GetEcsFilter(systems, _world);
            Initialization(systems, _world, _filter);
        }
        
        public void Run(IEcsSystems systems)
        {
            if (!IsSuccessfully(systems, _world, _filter)) return;
            foreach (var entity in _filter)
            {
                InForeach(systems, entity, _world, _filter);
            }
        }

        protected abstract bool IsSuccessfully(IEcsSystems systems, EcsWorld world, EcsFilter filter);
        protected abstract EcsFilter GetEcsFilter(IEcsSystems systems, EcsWorld world);
        protected abstract void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter);
        protected abstract void InForeach(IEcsSystems systems, int entity, EcsWorld world, EcsFilter filter);
    }
}