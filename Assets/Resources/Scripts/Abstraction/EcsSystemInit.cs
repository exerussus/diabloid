using Leopotam.EcsLite;
using Resources.Scripts.Data;

namespace Resources.Scripts.Abstraction
{
    public abstract class EcsSystemInit : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private GameData _gameData;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = GetFilter(_world);
            _gameData = systems.GetShared<GameData>();
            Initialization(systems, _world, _filter, _gameData);
        }

        protected abstract EcsFilter GetFilter(EcsWorld world);
        protected abstract void Initialization(IEcsSystems systems, EcsWorld world, EcsFilter filter, GameData gameData);
    }
}