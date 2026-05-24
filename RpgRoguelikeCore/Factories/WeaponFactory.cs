using RpgRoguelikeCore.Weapons;

namespace RpgRoguelikeCore.Factories
{
    public abstract class WeaponFactory
    {
        public abstract IWeapon CreateWeapon();
    }
}