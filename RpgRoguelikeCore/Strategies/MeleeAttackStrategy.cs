using System;
using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Strategies
{
    public class MeleeAttackStrategy : IAttackStrategy
    {
        public void Execute(Enemy enemy)
        {
            Console.Write($"{enemy.Name} производит атаку в ближнем бою. ");
            enemy.Weapon.Use();
        }
    }
}