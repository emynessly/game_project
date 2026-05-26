using System;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore.Entities
{
    public class Player
    {
        private const int DEFAULT_MAX_HEALTH = 100;
        private const string DEFAULT_NAME = "Рыцарь";
        
        private ILogger _logger;

        public string Name { get; set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public event Action<Player>? OnHealthChanged;

        public Player(ILogger logger, string name = DEFAULT_NAME, int maxHealth = DEFAULT_MAX_HEALTH)
        {
            _logger = logger;
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;

            _logger.Log($"{Name} получил {amount} урона. Осталось здоровья: {Health}/{MaxHealth}");
            OnHealthChanged?.Invoke(this);
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;

            _logger.Log($"{Name} вылечился на {amount}. Здоровье: {Health}/{MaxHealth}");
            OnHealthChanged?.Invoke(this);
        }

        public bool IsAlive() => Health > 0;
        
        public int X { get; set; }
        public int Y { get; set; }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            _logger.Log($"Игрок переместился на {X}, {Y}");
        }
    }
}