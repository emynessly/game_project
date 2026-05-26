using System;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore.States
{
    public class GameOverState : IGameState
    {
        private ILogger _logger;
        private GameManager _gameManager;
        
        public GameOverState(ILogger logger, GameManager gameManager)
        {
            _logger = logger;
            _gameManager = gameManager;
        }
        
        public void Enter()
        {
            _logger.Log("\n=== КОНЕЦ ИГРЫ ===");
            _logger.Log("Нажмите R чтобы начать заново");
            _logger.Log("Нажмите ESC чтобы выйти");
        }
        
        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    _gameManager.RestartGame();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
        
        public void Exit()
        {
            _logger.Log("Перезапуск игры...");
        }
    }
}