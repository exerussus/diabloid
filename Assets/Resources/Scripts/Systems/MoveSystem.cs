using Leopotam.EcsLite;
using Source.ECS.Components;
using UnityEngine;

namespace Source.ECS.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MoveComponent>().Inc<PlayerInputComponent>().End();
            var movePool = world.GetPool<MoveComponent>();
            var playerInputPool = world.GetPool<PlayerInputComponent>();

            foreach (var entity in filter)
            {
                ref var moveComponent = ref movePool.Get(entity);
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                moveComponent.Transform.position += (Vector3)playerInputComponent.Direction * (Time.deltaTime * moveComponent.MovementSpeed);
            }
            
        }
    }
}