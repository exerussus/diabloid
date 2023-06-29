using System;
using Leopotam.EcsLite;
using Source.ECS.Systems;
using UnityEngine;

namespace Resources.ECS
{
    public class Loader : MonoBehaviour
    {
        EcsWorld _world;
        IEcsSystems _initSystems;
        
        private void Start() 
        {        
            _world = new EcsWorld ();
            _initSystems = new EcsSystems (_world);
            _initSystems
                    
                .Add(new GameInit());

            _initSystems.Init ();
        }

        private void Update() 
        {
            // _systems?.Run();
        }

        private void OnDestroy() 
        {
            _initSystems.Destroy();
        }
    }
}