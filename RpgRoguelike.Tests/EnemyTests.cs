using RpgRoguelikeCore.Enemies;
using Xunit;

namespace RpgRoguelike.Tests
{
        public class EnemyTests
    {
        [Fact]
        public void TakingDamage_WithValidNumber_ReducesHealth()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(15);
            Assert.Equal(35, enemy.Health);
        }

        [Fact]
        public void TakingDamage_WithNumberMoreThanHealth_HealthGoesToZero()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(100);
            Assert.Equal(0, enemy.Health);
        }

        [Fact]
        public void TakingDamage_WithNumberEqualToHealth_HealthBecomesZero()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(50);
            Assert.Equal(0, enemy.Health);
        }

        [Fact]
        public void TakeDamage_WithZeroNumber_HealthUnchanged()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(0);
            Assert.Equal(50, enemy.Health);
        }

        [Fact]
        public void IsAlive_WhenHealthZero_ReturnsFalse()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(50);
            Assert.False(enemy.IsAlive());
        }
    }
}