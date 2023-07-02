using Resources.Scripts.Interfaces;
using UnityEngine;

namespace Resources.Scripts.Logic.Weapons
{
    public class Melee : IWeapon
    {
        public void Attack()
        {
            Debug.Log("Melee Attack!");
        }
    }
}