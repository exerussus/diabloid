using System;
using UnityEngine;

namespace Source.ECS.Entities
{
    [Serializable]
    public class CharacterData
    {
        [SerializeField] private CharacterType _сharacterType;
        public CharacterType CharacterType => _сharacterType;
        
        [SerializeField] private GameObject _сharacterPrefab;
        public GameObject CharacterPrefab => _сharacterPrefab;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;
    }

    public enum CharacterType
    {
        Player,
        Enemy
    }
}