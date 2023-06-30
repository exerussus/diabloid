
using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Characters", fileName = "Characters")]
    public class CharactersData : ScriptableObject
    {
        [SerializeField] private CharacterData[] _charactersData;
        public CharacterData[] Characters => _charactersData;
    }
}