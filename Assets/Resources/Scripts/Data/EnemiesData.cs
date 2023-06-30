
using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Enemies", fileName = "Enemies")]
    public class EnemiesData : ScriptableObject
    {
        [SerializeField] private CharacterData[] _charactersData;
        public CharacterData[] Enemies => _charactersData;
    }
}