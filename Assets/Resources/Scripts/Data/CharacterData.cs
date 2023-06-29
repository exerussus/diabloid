
using UnityEngine;

namespace Source.ECS.Entities
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