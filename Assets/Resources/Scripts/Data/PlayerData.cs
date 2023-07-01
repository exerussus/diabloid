

using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
    public class PlayerData : ScriptableObject
    {
        public int Entity;
        public CharacterData CharacterData;
    }
}