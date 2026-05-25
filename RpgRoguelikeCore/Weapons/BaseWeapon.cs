namespace RpgRoguelikeCore.Weapons
{
    public class BaseWeapon : IWeapon
    {
        protected string Name { get; set; }
        protected int Damage { get; set; }
        
        public BaseWeapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        public virtual int GetDamage() => Damage;
        public virtual string GetName() => Name;
    }
}