using RpgRoguelikeCore.Enemies;
using Xunit;

namespace RpgRoguelike.Tests
{
        public class EnemyTests
    {
        private const int TEST_DAMAGE = 15;
        private const int OVERKILL_DAMAGE = 100;
        private const int GOBLIN_HEALTH = 50;

        [Fact]
        public void TakingDamage_WithValidNumber_ReducesHealth()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(TEST_DAMAGE);
            Assert.Equal(35, enemy.Health);
        }

        [Fact]
        public void TakingDamage_WithNumberMoreThanHealth_HealthGoesToZero()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(OVERKILL_DAMAGE);
            Assert.Equal(0, enemy.Health);
        }

        [Fact]
        public void TakingDamage_WithNumberEqualToHealth_HealthBecomesZero()
        {
            var enemy = new Goblin();
            enemy.TakeDamage(GOBLIN_HEALTH);
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