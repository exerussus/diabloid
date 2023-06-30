using Leopotam.EcsLite;
using Source.ECS.Components;
using UnityEngine;


namespace Source.ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var filter = world.Filter<PlayerInputComponent>().End();
            var playerInputPool = world.GetPool<Components.PlayerInputComponent>();
            
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputPool.Get(entity);
                playerInputComponent.Direction = new Vector2(x, y);
            }
        }
    }
}