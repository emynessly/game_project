using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Factories
{
    public class StaffFactory : WeaponFactory
    {
        public override Weapon CreateWeapon()
        {
            return new Staff();
        }
    }
}