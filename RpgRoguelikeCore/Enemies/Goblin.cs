using System;
using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Enemies
{
    public class Goblin : Enemy
    {
        public Goblin() : base("Гоблин", health: 50, new Weapon("Кинжал", 8))
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