using System;
using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton() : base("Скелет", health: 30, new Weapon("Костяной лук", 12))
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