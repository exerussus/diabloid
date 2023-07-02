using Resources.Scripts.Interfaces;

namespace Resources.Scripts.Components
{
    public struct WeaponComponent
    {
        public IWeapon Weapon;
        public float Range;
        public float CoolDownValue;
        public float CoolDownTimer;
        public bool IsReady => CoolDownTimer >= CoolDownValue;
    }
}