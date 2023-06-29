
using Leopotam.EcsLite;
using Source.ECS.Components;

namespace Source.ECS.Systems
{
    public class GameInit : IEcsInitSystem
    {
        private EcsWorld _world = null;
        
        public void Init(IEcsSystems systems)
        {
            var player = _world.NewEntity();
            
            var movable = _world.GetPool<Movable>();
            var inputEvent = _world.GetPool<InputEvent>();
            
            movable.Add(player);
            inputEvent.Add(player);
        }
    }
}