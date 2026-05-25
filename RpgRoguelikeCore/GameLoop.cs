using System;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore
{
    public class GameLoop
    {
        private bool _isRunning;
        private ILogger _logger;
        
        public GameLoop(ILogger logger)
        {
            _logger = logger;
            _isRunning = true;
        }
        
        public void Run()
        {
            _logger.Log("Press ESC to quit");
            
            while (_isRunning)
            {
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