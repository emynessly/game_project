using System;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.States;
using RpgRoguelikeCore.Entities;
using RpgRoguelikeCore.Commands;
using RpgRoguelikeCore.Input;

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
        private GameLoop _gameLoop;
        private InputHandler _inputHandler;
        private Stack<ICommand> _history;

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
            _history = new Stack<ICommand>();

            _inputHandler = new InputHandler();
            _inputHandler.BindKey(ConsoleKey.W, new MoveCommand(_player, 0, -1));
            _inputHandler.BindKey(ConsoleKey.A, new MoveCommand(_player, -1, 0));
            _inputHandler.BindKey(ConsoleKey.S, new MoveCommand(_player, 0, 1));
            _inputHandler.BindKey(ConsoleKey.D, new MoveCommand(_player, 1, 0));

            MenuState = new MenuState(_logger, this);
            GameState = new GameState(_logger, this, _player, _demoRunner);
            PauseState = new PauseState(_logger, this);
            GameOverState = new GameOverState(_logger, this);
            
            _currentState = MenuState;
            _gameLoop = new GameLoop(_logger, this);
        }
        
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);

        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                ICommand command = _history.Pop();
                command.Undo();
            }
        }

        public InputHandler GetInputHandler() => _inputHandler;

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
            _gameLoop.Run();
        }
    }
}