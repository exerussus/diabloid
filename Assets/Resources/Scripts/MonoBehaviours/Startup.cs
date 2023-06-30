﻿
using System;
using Leopotam.EcsLite;
using Source.ECS.Entities;
using Source.ECS.Systems;
using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;
        private IEcsSystems _initSystems;
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private GameData _gameData;
        [SerializeField] private CharacterData _playerData;
        [SerializeField] private CharactersData _charactersData;
        
        private void Start() 
        {        
            _world = new EcsWorld();
            _gameData = GetGameData();

            PrepareInitSystems();
            PrepareUpdateSystems();
            PrepareFixedUpdateSystems();
        }

        private void Update() 
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void PrepareInitSystems()
        {
            _initSystems = new EcsSystems(_world, _gameData);
            _initSystems
                    
                .Add(new PlayerInitSystem());
            
            _initSystems.Init();
        }
        
        private void PrepareUpdateSystems()
        {
            _updateSystems = new EcsSystems(_world, _gameData);
            _updateSystems
                    
                .Add(new PlayerInputSystem());
            
            _updateSystems.Init();
        }
        
        private void PrepareFixedUpdateSystems()
        {
            _fixedUpdateSystems = new EcsSystems(_world, _gameData);
            _fixedUpdateSystems
                    
                .Add(new MoveSystem());
            
            _fixedUpdateSystems.Init();
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