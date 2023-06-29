
using Leopotam.EcsLite;
using Source.ECS.Entities;
using Source.ECS.Systems;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        EcsWorld _world;
        IEcsSystems _initSystems;
        [SerializeField] private CharacterData _playerData;
        [SerializeField] private CharactersData _charactersData;
        
        private void Start() 
        {        
            _world = new EcsWorld ();
            var gameData = GetGameData();
            
            _initSystems = new EcsSystems (_world, gameData);
            _initSystems
                    
                .Add(new PlayerInit());

            _initSystems.Init ();
        }

        private void Update() 
        {
            // _systems?.Run();
        }

        private GameData GetGameData()
        {
            var gameData = new GameData();
            gameData.CharactersData = _charactersData;
            gameData.PlayerData = _playerData;
            return gameData;
        }
        
        private void OnDestroy() 
        {
            _initSystems.Destroy();
        }
    }
}