using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Factories
{
    public class SwordFactory : WeaponFactory
    {
        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
}