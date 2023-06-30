using UnityEngine;

namespace Resources.Scripts.MonoBehaviours
{
    public class WorldInfo : MonoBehaviour
    { 
        [SerializeField] private Transform[] _spawners;
        public Transform[] Spawners => _spawners;
    }
}