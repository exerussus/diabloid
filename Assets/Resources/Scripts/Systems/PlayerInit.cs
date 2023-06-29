
using Leopotam.EcsLite;
using Source.ECS.Components;
using Source.ECS.Entities;
using UnityEngine;

namespace Source.ECS.Systems
{
    public class PlayerInit : IEcsInitSystem
    {
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var gameData = systems.GetShared<GameData>();
            
            var player = world.NewEntity();
            
            var movable = world.GetPool<Movable>();
            var inputEvent = world.GetPool<InputEvent>();
            
            ref var movablePlayer = ref movable.Add(player);
            ref var inputEventPlayer = ref inputEvent.Add(player);

            var playerData = gameData.PlayerData;

            var spawnedPlayerPrefab = GameObject.Instantiate(playerData.CharacterPrefab);
            movablePlayer.MovementSpeed = playerData.MovementSpeed;
            movablePlayer.Transform = spawnedPlayerPrefab.transform;

        }
    }
}