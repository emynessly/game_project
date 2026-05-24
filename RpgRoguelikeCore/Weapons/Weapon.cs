using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        public virtual void Use()
        {
        Console.WriteLine($"Атака оружием {Name} наносит урон: {Damage}");
        }

         public Weapon Clone()
        {
            return new Weapon(Name, Damage);
        }
    }
}