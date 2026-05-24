using System;

namespace RpgRoguelikeCore.Weapons
{
    public abstract class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        
        protected Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        public abstract void Use();
    }
}