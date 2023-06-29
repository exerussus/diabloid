
using UnityEngine;

namespace Source.ECS.Entities
{
    [CreateAssetMenu(menuName = "Data/Characters", fileName = "Characters")]
    public class CharactersData : ScriptableObject
    {
        [SerializeField] private CharacterData[] _charactersData;
        public CharacterData[] Characters => _charactersData;
    }
}