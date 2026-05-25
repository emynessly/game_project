using System;
using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Enemies
{
    public class Skeleton : Enemy
    {
        private const int DEFAULT_HEALTH = 30;
        private const string DEFAULT_WEAPON_NAME = "Костяной лук";
        private const int DEFAULT_WEAPON_DAMAGE = 12;
        public Skeleton() : base("Скелет", DEFAULT_HEALTH, new Weapon(DEFAULT_WEAPON_NAME, DEFAULT_WEAPON_DAMAGE))
        {
        }
        
        private Skeleton(Skeleton original) : base(original.Name, original.Health, original.Weapon.Clone())
        {
        }
        
        public override void Attack()
        {
            Weapon.Use();
        }
        
        public override Enemy Clone()
        {
            return new Skeleton(this);
        }
    }
}