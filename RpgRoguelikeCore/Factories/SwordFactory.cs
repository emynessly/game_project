using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Factories
{
    public class SwordFactory : WeaponFactory
    {
        public override IWeapon CreateWeapon()
        {
            return new Sword();
        }
    }
}