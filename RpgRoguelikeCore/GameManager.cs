using System;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.States;
using RpgRoguelikeCore.Entities;

namespace RpgRoguelikeCore
{
    public class GameManager
    {
        private static GameManager? _instance;
        private ILogger _logger;
        private IGameState _currentState;
        private Player _player;
        private DemoRunner _demoRunner;
        private GameSettings _settings;

        public IGameState MenuState { get; private set; }
        public IGameState GameState { get; private set; }
        public IGameState PauseState { get; private set; }
        public IGameState GameOverState { get; private set; }
        
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
            _player = new Player(_logger);
            _demoRunner = new DemoRunner(_logger, _settings);

            MenuState = new MenuState(_logger, this);
            GameState = new GameState(_logger, this, _player, _demoRunner);
            PauseState = new PauseState(_logger, this);
            GameOverState = new GameOverState(_logger, this);
            
            _currentState = MenuState;
        }
        
        public void SetState(IGameState newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        public void RestartGame()
        {
            _player = new Player(_logger);
            SetState(MenuState);
        }
        
        public void Run()
        {
            _currentState.Enter();
            
            while (true)
            {
                _currentState.Update();
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}