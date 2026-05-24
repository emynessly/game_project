namespace RpgRoguelikeCore.Weapons
{
    public class PoisonDecorator : WeaponDecorator
    {
        private int _poisonDamage;
        
        public PoisonDecorator(IWeapon weapon, int poisonDamage) : base(weapon)
        {
            _poisonDamage = poisonDamage;
        }
        
        public override int GetDamage() => _weapon.GetDamage() + _poisonDamage;
        
        public override string GetName() => $"{_weapon.GetName()} (отравлен +{_poisonDamage})";
    }
}