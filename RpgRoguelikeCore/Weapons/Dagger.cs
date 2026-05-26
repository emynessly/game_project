namespace RpgRoguelikeCore.Weapons
{
    public class Dagger : BaseWeapon
    {
        private const int DEFAULT_DAMAGE = 8;
        private const string DEFAULT_NAME = "Кинжал";

        public Dagger() : base(DEFAULT_NAME, DEFAULT_DAMAGE)
        {
        }
    }
}