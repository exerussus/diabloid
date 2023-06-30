using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/World", fileName = "World")]
    public class WorldData : ScriptableObject
    {
        [SerializeField] private GameObject _worldPrefab;
        public GameObject WorldPrefab => _worldPrefab;
    }
}