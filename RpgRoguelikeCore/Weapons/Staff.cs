using System;

namespace RpgRoguelikeCore.Weapons
{
    public class Staff : Weapon
    {
        public Staff() : base("Посох", damage: 10)
        {
        }
        
        public override void Use()
        {
            Console.WriteLine($"Вы произносите заклинание {Name} и наносите урон: {Damage}");
        }
    }
}