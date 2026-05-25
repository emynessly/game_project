using System;
using RpgRoguelikeCore.Factories;
using RpgRoguelikeCore.Weapons;
using RpgRoguelikeCore.Enemies;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class GameManager
    {
        private static GameManager? _instance;
        private ILogger _logger;
        
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

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public Difficulty Difficulty { get; set; }
        
        private bool isRunning;
        
        private GameManager()
        {
            MapWidth = 100;
            MapHeight = 100;
            Difficulty = Difficulty.Normal;
            isRunning = true;

            var externalLogger = new ExternalLogger();
            _logger = new LoggerAdapter(externalLogger);
        }
        
        public void Run()
        {
            _logger.Log($"Game Started with difficulty: {Difficulty}");

            EnemyFactory factory = new GoblinFactory();
            Enemy enemy = factory.CreateEnemy();

            _logger.Log("\n - Враг создан через фабрику - ");
            enemy.Attack();

            _logger.Log("\n - Работа Prototype - ");
    
            Enemy original = new Goblin();
            Enemy clone = original.Clone();

            _logger.Log($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");

            clone.Health = 500;
            clone.Weapon.Name = "Топорик";

            _logger.Log($"Клон после изменений: здоровье {clone.Health}, оружие {clone.Weapon.Name}");
            _logger.Log($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");
            _logger.Log($"Сравнение оригинала и клона. Они разные: {!ReferenceEquals(original, clone)}");

            // декораторы

            _logger.Log("\n - Работа Decorator (цепочка декораторов) - ");
            
            IWeapon dagger = new Dagger();
            _logger.Log($"База: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            dagger = new PoisonDecorator(dagger, 5);
            _logger.Log($"+Яд: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            dagger = new FireDecorator(dagger, 4);
            _logger.Log($"+Огонь: {dagger.GetName()} -> {dagger.GetDamage()} урона");

            dagger = new RustDecorator(dagger, 3);
            _logger.Log($"+Ржавчина: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            _logger.Log($"\nИтоговый урон: {dagger.GetDamage()}");
            
            _logger.Log("\n Press ESC to quit");
            
            while (isRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }
}