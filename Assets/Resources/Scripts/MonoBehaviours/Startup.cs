
using Cinemachine;
using Leopotam.EcsLite;
using Resources.Scripts.Data;
using Resources.Scripts.Systems;
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
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private EnemiesData enemiesData;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private WorldData[] _worldsData;
        
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
                .Add(new WorldInitSystem())    
                .Add(new PlayerInitSystem());
            
            _initSystems.Init();
        }
        
        private void PrepareUpdateSystems()
        {
            _updateSystems = new EcsSystems(_world, _gameData);
            _updateSystems
                    
                .Add(new PlayerMovementInputSystem())
                .Add(new EnemyMovementInputSystem())
                .Add(new PlayerWeaponInputSystem())
                .Add(new EnemyWeaponInputSystem());
            
            _updateSystems.Init();
        }
        
        private void PrepareFixedUpdateSystems()
        {
            _fixedUpdateSystems = new EcsSystems(_world, _gameData);
            _fixedUpdateSystems
                    
                .Add(new MoveSystem())
                .Add(new EnemySpawnSystem())
                .Add(new WeaponAttackSystem())
                .Add(new ResourcesRegenerationSystem());
            
            _fixedUpdateSystems.Init();
        }
        
        private GameData GetGameData()
        {
            var gameData = new GameData();
            gameData.EnemiesData = enemiesData;
            gameData.PlayerData = _playerData;
            gameData.CinemachineVirtualCamera = _cinemachineVirtualCamera;
            gameData.WorldsData = _worldsData;
            return gameData;
        }
        
        private void OnDestroy() 
        {
            _initSystems.Destroy();
        }
    }
}