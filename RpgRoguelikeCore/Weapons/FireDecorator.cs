namespace RpgRoguelikeCore.Weapons
{
    public class FireDecorator : WeaponDecorator
    {
        private int _fireDamage;
        
        public FireDecorator(IWeapon weapon, int fireDamage) : base(weapon)
        {
            _fireDamage = fireDamage;
        }
        
        public override int GetDamage() => _weapon.GetDamage() + _fireDamage;
        
        public override string GetName() => $"{_weapon.GetName()} (огненный +{_fireDamage})";
    }
}