
using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Character", fileName = "Character")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private GameObject _сharacterPrefab;
        public GameObject CharacterPrefab => _сharacterPrefab;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;
    }
}