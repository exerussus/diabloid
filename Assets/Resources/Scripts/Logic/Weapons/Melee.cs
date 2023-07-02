using Resources.Scripts.Interfaces;
using UnityEngine;

namespace Resources.Scripts.Logic.Weapons
{
    public class Melee : IWeapon
    {
        public void Attack(Transform entityTransform)
        {
            Debug.Log("Melee Attack!");
        }
    }
}