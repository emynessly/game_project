using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Sword : Weapon
    {
        public Sword() : base("Меч", damage: 15)
        {
        }
        
        public override void Use()
        {
            Console.WriteLine($"Вы делаете удар {Name} и наносите урон: {Damage}");
        }
    }
}