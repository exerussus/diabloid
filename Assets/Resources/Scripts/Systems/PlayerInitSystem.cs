﻿
using Leopotam.EcsLite;
using Resources.Scripts.Components;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var gameData = systems.GetShared<GameData>();
            var player = world.NewEntity();
            var playerData = gameData.PlayerData;
            playerData.Entity = player;
            
            var movePool = world.GetPool<MoveComponent>();
            var inputEventPool = world.GetPool<PlayerInputComponent>();
            
            inputEventPool.Add(player);
            ref var moveComponent = ref movePool.Add(player);
            
            CreatePlayer(ref moveComponent, playerData);
        }

        private void CreatePlayer(ref MoveComponent moveComponent, CharacterData playerData)
        {
            var spawnedPlayerPrefab = GameObject.Instantiate(playerData.CharacterPrefab);
            moveComponent.MovementSpeed = playerData.MovementSpeed;
            moveComponent.Transform = spawnedPlayerPrefab.transform;
        }
    }
}