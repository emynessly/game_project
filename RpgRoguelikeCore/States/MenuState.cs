using System;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore.States
{
    public class MenuState : IGameState
    {
        private ILogger _logger;
        private GameManager _gameManager;

        public MenuState(ILogger logger, GameManager gameManager)
        {
            _logger = logger;
            _gameManager = gameManager;
        }

        public void Enter()
        {
            _logger.Log("\n - Меню - ");
            _logger.Log("Нажмите Enter для начала игры");
            _logger.Log("Нажмите ESC для выхода");
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    _gameManager.SetState(_gameManager.GameState);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void Exit()
        {
            _logger.Log("Выход из меню");
        }
    }
}