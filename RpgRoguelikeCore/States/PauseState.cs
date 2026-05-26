using System;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore.States
{
    public class PauseState : IGameState
    {
        private ILogger _logger;
        private GameManager _gameManager;
        
        public PauseState(ILogger logger, GameManager gameManager)
        {
            _logger = logger;
            _gameManager = gameManager;
        }
        
        public void Enter()
        {
            _logger.Log("\n=== ПАУЗА ===");
            _logger.Log("Нажмите ESC чтобы продолжить");
        }
        
        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    _gameManager.SetState(_gameManager.GameState);
                }
            }
        }
        
        public void Exit()
        {
            _logger.Log("Продолжение игры...");
        }
    }
}