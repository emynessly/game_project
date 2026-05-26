using System;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.Entities;

namespace RpgRoguelikeCore.States
{
    public class GameState : IGameState
    {
        private ILogger _logger;
        private GameManager _gameManager;
        private Player _player;
        private DemoRunner _demoRunner;
        
        public GameState(ILogger logger, GameManager gameManager, Player player, DemoRunner demoRunner)
        {
            _logger = logger;
            _gameManager = gameManager;
            _player = player;
            _demoRunner = demoRunner;
        }
        
        public void Enter()
        {
            _logger.Log("\n=== ИГРА ===");
            _logger.Log("Нажмите ESC для паузы");
            _logger.Log("Нажмите H для лечения");
            _logger.Log("Нажмите D для получения урона");
            
            // Запускаем демонстрации
            _demoRunner.RunAllDemos();
        }
        
        public void Update()
        {
            // Проверка на смерть
            if (!_player.IsAlive())
            {
                _gameManager.SetState(_gameManager.GameOverState);
                return;
            }
            
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    _gameManager.SetState(_gameManager.PauseState);
                }
                else if (key.Key == ConsoleKey.H)
                {
                    _player.Heal(20);
                }
                else if (key.Key == ConsoleKey.D)
                {
                    _player.TakeDamage(15);
                }
            }
        }
        
        public void Exit()
        {
            _logger.Log("Пауза...");
        }
    }
}