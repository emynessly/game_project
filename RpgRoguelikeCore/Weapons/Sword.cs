using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Sword : BaseWeapon
    {
        private const int DEFAULT_DAMAGE = 15;
        private const string DEFAULT_NAME = "Меч";
        
        public Sword() : base(DEFAULT_NAME, DEFAULT_DAMAGE)
        {
        }
    }
}