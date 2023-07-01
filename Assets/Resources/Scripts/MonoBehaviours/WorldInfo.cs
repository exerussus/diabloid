using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class WorldInfo : MonoBehaviour
    { 
        [SerializeField] private Transform[] _enemySpawners;
        public Transform[] EnemySpawners => _enemySpawners;
        
        [SerializeField] private Transform _playerSpawner;
        public Transform PlayerSpawner => _playerSpawner;
    }
}