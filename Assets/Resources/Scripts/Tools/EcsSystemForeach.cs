
using Leopotam.EcsLite;

namespace Resources.Scripts.Tools
{
    public abstract class EcsSystemForeach : IEcsRunSystem, IEcsInitSystem
    {
        protected EcsWorld _world;
        protected EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = GetEcsWorld(systems);
            _filter = GetEcsFilter(systems);
            Initialization(systems);
        }
        
        public void Run(IEcsSystems systems)
        {
            BeforeForeach(systems);
            foreach (var entity in _filter)
            {
                Foreach(systems, entity);
            }
        }

        protected abstract EcsWorld GetEcsWorld(IEcsSystems systems);
        protected abstract EcsFilter GetEcsFilter(IEcsSystems systems);
        protected abstract void Initialization(IEcsSystems systems);
        protected abstract void BeforeForeach(IEcsSystems systems);
        protected abstract void Foreach(IEcsSystems systems, int entity);
        
    }
}