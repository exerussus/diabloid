
using Leopotam.EcsLite;
using Source.ECS.Components;
using Source.ECS.Entities;
using UnityEngine;

namespace Source.ECS.Systems
{
    public class GameInit : IEcsInitSystem
    {
        private EcsWorld _world = null;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            var player = _world.NewEntity();
            
            var movable = _world.GetPool<Movable>();
            var inputEvent = _world.GetPool<InputEvent>();
            
            ref var movablePlayer = ref movable.Add(player);
            ref var inputEventPlayer = ref inputEvent.Add(player);

            var playerData = GetPlayerCharacterData();
            
            var spawnedPlayerPrefab = GameObject.Instantiate(playerData.CharacterPrefab);
            movablePlayer.MovementSpeed = playerData.MovementSpeed;
            movablePlayer.Transform = spawnedPlayerPrefab.transform;

        }

        private CharacterData GetPlayerCharacterData()
        {
            var charactersDataFile = UnityEngine.Resources.Load<CharactersData>("Data/CharactersData");
            var charactersData = charactersDataFile.Characters;

            foreach (var characterData in charactersData)
            {
                if (characterData.CharacterType == CharacterType.Player) return characterData;
            }

            return null;
        }
    }
}