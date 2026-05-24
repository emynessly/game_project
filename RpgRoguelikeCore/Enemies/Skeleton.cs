using System;

namespace RpgRoguelikeCore.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton() : base("Скелет", health: 35, damage: 10)
        {
        }
        
        public override void Attack()
        {
            Console.WriteLine($"{Name} стреляет из лука и наносит урон: {Damage}");
        }
    }
}