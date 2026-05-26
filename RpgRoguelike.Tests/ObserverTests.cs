using RpgRoguelikeCore.Entities;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.UI;
using Xunit;

namespace RpgRoguelike.Tests
{
    public class ObserverTests
    {
        private class TestLogger : ILogger
        {
            public string? LastMessage { get; private set; }
            public void Log(string message) => LastMessage = message;
        }

        [Fact]
        public void Player_OnHealthChanged_ShouldTriggerEvent()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            bool eventTriggered = false;
            
            player.OnHealthChanged += (p) => eventTriggered = true;
            player.TakeDamage(20);
            
            Assert.True(eventTriggered);
        }
        
        [Fact]
        public void ConsoleHUD_Subscribe_ShouldUpdateOnDamage()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            var hud = new ConsoleHUD(logger);
            
            hud.Subscribe(player);
            player.TakeDamage(30);
            
            Assert.Contains("70/100", logger.LastMessage);
        }
        
        [Fact]
        public void Player_Health_ShouldNotGoBelowZero()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            
            player.TakeDamage(200);
            
            Assert.Equal(0, player.Health);
        }
    }
}
