using System;

namespace RpgRoguelikeCore.Enemies
{
    public class Goblin : Enemy
    {
        public Goblin() : base("Гоблин", health: 50, damage: 8)
        {
        }
        
        public override void Attack()
        {
            Console.WriteLine($"{Name} вонзает кинжал и наносит урон: {Damage}");
        }
    }
}