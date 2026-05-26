using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Staff : BaseWeapon
    {
        private const int DEFAULT_DAMAGE = 10;
        private const string DEFAULT_NAME = "Посох";

        public Staff() : base(DEFAULT_NAME, DEFAULT_DAMAGE)
        {
        }
    }
}