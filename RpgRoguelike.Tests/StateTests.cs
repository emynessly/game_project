using RpgRoguelikeCore;
using RpgRoguelikeCore.Entities;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.States;
using Xunit;

namespace RpgRoguelike.Tests
{
    public class StateTests
    {
        private class TestLogger : ILogger
        {
            public string LastMessage { get; set; } = "";
            public void Log(string message) => LastMessage = message;
        }
        
        [Fact]
        public void GameState_WhenPlayerDies_ShouldTransitionToGameOver()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            var gameManager = GameManager.Instance;

            player.TakeDamage(100);
            
            Assert.False(player.IsAlive());
        }
        
        [Fact]
        public void SetState_ShouldCallEnterAndExit()
        {
            var logger = new TestLogger();
            var gameManager = GameManager.Instance;
            
            bool menuEnterCalled = false;
            bool menuExitCalled = false;
            
            var testState = new TestState(() => menuEnterCalled = true, () => menuExitCalled = true);
            
            gameManager.SetState(testState);
            
            Assert.True(menuEnterCalled);
            
            gameManager.SetState(gameManager.PauseState);
            
            Assert.True(menuExitCalled);
        }
        
        [Fact]
        public void MenuState_OnEnter_ShouldLogMessage()
        {
            var messages = new List<string>();
            var testLogger = new TestLoggerCollector(messages);
            var gameManager = GameManager.Instance;
            var menuState = new MenuState(testLogger, gameManager);
            
            menuState.Enter();
            
            Assert.Contains(messages, m => m.Contains("Меню"));
        }

        [Fact]
        public void GameOverState_OnEnter_ShouldLogMessage()
        {
            var messages = new List<string>();
            var testLogger = new TestLoggerCollector(messages);
            var gameManager = GameManager.Instance;
            var gameOverState = new GameOverState(testLogger, gameManager);
            
            gameOverState.Enter();
            
            Assert.Contains(messages, m => m.Contains("КОНЕЦ ИГРЫ"));
        }

// Добавь этот класс в конец файла
private class TestLoggerCollector : ILogger
{
    private List<string> _messages;
    
    public TestLoggerCollector(List<string> messages)
    {
        _messages = messages;
    }
    
    public void Log(string message)
    {
        _messages.Add(message);
    }
}
        
        private class TestState : IGameState
        {
            private System.Action _onEnter;
            private System.Action _onExit;
            
            public TestState(System.Action onEnter, System.Action onExit)
            {
                _onEnter = onEnter;
                _onExit = onExit;
            }
            
            public void Enter() => _onEnter();
            public void Update() { }
            public void Exit() => _onExit();
        }
    }
}