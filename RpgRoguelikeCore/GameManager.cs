using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore
{
    public class GameManager
    {
        private static GameManager? _instance;
        private ILogger _logger;
        private GameSettings _settings;
        private DemoRunner _demoRunner;
        private GameLoop _gameLoop;
        
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
        
        private GameManager()
        {
            var externalLogger = new ExternalLogger();
            _logger = new LoggerAdapter(externalLogger);
            
            _settings = new GameSettings();
            _demoRunner = new DemoRunner(_logger, _settings);
            _gameLoop = new GameLoop(_logger);
        }
        
        public void Run()
        {
            _demoRunner.RunAllDemos();
            _gameLoop.Run();
        }
    }
}