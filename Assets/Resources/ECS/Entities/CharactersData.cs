using UnityEngine;

namespace Source.ECS.Entities
{
    [CreateAssetMenu(menuName = "Entities/CharactersData", fileName = "CharactersData")]
    public class CharactersData : ScriptableObject
    {
        [SerializeField] private CharacterData[] _charactersData;
        public CharacterData[] Characters => _charactersData;
    }
}