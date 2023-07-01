using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Class", fileName = "Class")]
    public class ClassData : ScriptableObject
    {
        public string Name => _name;
        public int Strength => _strength;
        public int Constitution => _constitution;
        public int Wisdom => _wisdom;
        public int Agility => _agility;
        
        [SerializeField] private string _name;
        
        [SerializeField] private int _strength;

        [SerializeField] private int _constitution;
        
        [SerializeField] private int _wisdom;
        
        [SerializeField] private int _agility;
    }
}