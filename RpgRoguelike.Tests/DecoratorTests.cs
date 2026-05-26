using RpgRoguelikeCore.Weapons;
using Xunit;

namespace RpgRoguelike.Tests
{
    public class DecoratorTests
    {
        [Fact]
        public void WeaponDecorator_ChainOfThreeDecorators_CalculatesCorrectly()
        {
            IWeapon weapon = new Dagger();

            weapon = new PoisonDecorator(weapon, 5);
            weapon = new FireDecorator(weapon, 7);
            weapon = new RustDecorator(weapon, 4);

            Assert.Equal(16, weapon.GetDamage());
        }
    }
}