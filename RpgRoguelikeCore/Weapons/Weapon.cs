using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        public virtual int GetDamage() => Damage;

        public virtual string GetName() => Name;

        public virtual void Use()
        {
        Console.WriteLine($"Атака оружием {Name} наносит урон: {GetDamage}");
        }

         public Weapon Clone()
        {
            return new Weapon(Name, Damage);
        }
    }
}