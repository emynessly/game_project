using System;
using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Enemies
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Weapon Weapon { get; set; }
        
        protected Enemy(string name, int health, Weapon weapon)
        {
            Name = name;
            Health = health;
            Weapon = weapon;
        }
        
        public abstract void Attack();
        public abstract Enemy Clone();

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получил {amount} урона. Осталось здоровья: {Health}");
        }
        
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}