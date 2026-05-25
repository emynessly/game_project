using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Factories
{
    public class StaffFactory : WeaponFactory
    {
        public override IWeapon CreateWeapon()
        {
            return new Staff();
        }
    }
}