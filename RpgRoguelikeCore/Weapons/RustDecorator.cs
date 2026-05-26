using System;

namespace RpgRoguelikeCore.Weapons
{
    public class RustDecorator : WeaponDecorator
    {
        private int _penalty;
        
        public RustDecorator(IWeapon weapon, int penalty) : base(weapon)
        {
            _penalty = penalty;
        }
        
        public override int GetDamage() => Math.Max(0, _weapon.GetDamage() - _penalty);
        
        public override string GetName() => $"{_weapon.GetName()} (ржавый -{_penalty})";
    }
}