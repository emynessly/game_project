namespace RpgRoguelikeCore.Weapons
{
    public abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon _weapon;
        
        protected WeaponDecorator(IWeapon weapon)
        {
            _weapon = weapon;
        }
        
        public virtual int GetDamage() => _weapon.GetDamage();
        public virtual string GetName() => _weapon.GetName();
    }
}