using System;

namespace RpgRoguelikeCore.Enemies
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        
        protected Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        
        public abstract void Attack();
        
        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} получил {amount} урона. Осталось здоровья: {Health}");
        }
        
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}