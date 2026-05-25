using System;
using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Strategies
{
    public class RangedAttackStrategy : IAttackStrategy
    {
        private Random _random = new Random();
        private int _hitChance; // шанс попадания в процентах (0-100)
        
        public RangedAttackStrategy(int hitChance = 70)
        {
            _hitChance = hitChance;
        }
        
        public void Execute(Enemy enemy)
        {
            int roll = _random.Next(1, 101);
            
            if (roll <= _hitChance)
            {
                Console.Write($"{enemy.Name} атакует издалека. ");
                enemy.Weapon.Use();
            }
            else
            {
                Console.WriteLine($"{enemy.Name} выстрелил, но промахнулся. (шанс попадания: {_hitChance}%)");
            }
        }
    }
}