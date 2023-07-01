using UnityEngine;

namespace Resources.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Class", fileName = "Class")]
    public class ClassData : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
        [SerializeField] private int _strength;
        public int Strength => _strength;
        [SerializeField] private int _wisdom;
        public int Wisdom => _wisdom;
        [SerializeField] private int _agility;
        public int Agility => _agility;
    }
}