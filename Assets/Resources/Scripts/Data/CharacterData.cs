
using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Character", fileName = "Character")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private GameObject _сharacterPrefab;
        public GameObject CharacterPrefab => _сharacterPrefab;
        
        [SerializeField] private int _level;
        public int Level => _level;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [SerializeField] private ClassData _classData;
        public ClassData ClassData => _classData;
    }
}