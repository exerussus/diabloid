﻿
using Leopotam.EcsLite;

namespace Resources.Scripts.Abstraction
{
    public abstract class EcsSystemForeach : IEcsRunSystem, IEcsInitSystem
    {
        protected EcsWorld _world;
        protected EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = GetEcsFilter(systems);
            Initialization(systems);
        }
        
        public void Run(IEcsSystems systems)
        {

            foreach (var entity in _filter)
            {
                InForeach(systems, entity);
            }
        }
        
        protected abstract EcsFilter GetEcsFilter(IEcsSystems systems);
        protected abstract void Initialization(IEcsSystems systems);
        protected abstract void InForeach(IEcsSystems systems, int entity);
    }
}