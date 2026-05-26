using System;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.Input;

namespace RpgRoguelikeCore
{
    public class GameLoop
    {
        private bool _isRunning;
        private ILogger _logger;
        private GameManager _gameManager;
        
        public GameLoop(ILogger logger, GameManager gameManager)
        {
            _logger = logger;
            _gameManager = gameManager;
            _isRunning = true;
        }
        
        public void Run()
        {
            _logger.Log("WASD to move, Ctrl+Z to undo");
            _logger.Log("Press ESC to quit");

            var inputHandler = _gameManager.GetInputHandler();
            
            while (_isRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Z && (key.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        _gameManager.Undo();
                        continue;
                    }
                }
            
                var command = inputHandler.GetCommand();
                if (command != null)
                {
                    _gameManager.ExecuteCommand(command);
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        _isRunning = false;
                    }
                }
            }
        }
        
        public void Stop()
        {
            _isRunning = false;
        }
    }
}