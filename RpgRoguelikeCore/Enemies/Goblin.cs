using System;
using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Enemies
{
    public class Goblin : Enemy
    {
        private const int DEFAULT_HEALTH = 50;
        private const string DEFAULT_WEAPON_NAME = "Кинжал";
        private const int DEFAULT_WEAPON_DAMAGE = 8;

        public Goblin() : base("Гоблин", DEFAULT_HEALTH, new Weapon(DEFAULT_WEAPON_NAME, DEFAULT_WEAPON_DAMAGE))
        {
        }
        
        private Goblin(Goblin original) : base(original.Name, original.Health, original.Weapon.Clone())
        {
        }

        public override void Attack()
        {
            Weapon.Use();
        }

        public override Enemy Clone()
        {
            return new Goblin(this);
        }
    }
}