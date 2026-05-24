using System;
using RpgRoguelikeCore.Factories;
using RpgRoguelikeCore.Weapons;
using RpgRoguelikeCore.Enemies;

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
        private static GameManager _instance;
        
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
        }
        
        public void Run()
        {
            Console.WriteLine($"Game Started with difficulty: {Difficulty}");

            EnemyFactory factory = new GoblinFactory();
            Enemy enemy = factory.CreateEnemy();

            Console.WriteLine("\n - Враг создан через фабрику - ");
            enemy.Attack();

            Console.WriteLine("\n - Работа Prototype - ");
    
            Enemy original = new Goblin();
            Enemy clone = original.Clone();

            Console.WriteLine($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");

            clone.Health = 500;
            clone.Weapon.Name = "Топорик";

            Console.WriteLine($"Клон после изменений: здоровье {clone.Health}, оружие {clone.Weapon.Name}");
            Console.WriteLine($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");
            Console.WriteLine($"Сравнение оригинала и клона. Они разные: {!ReferenceEquals(original, clone)}");
            
            Console.WriteLine("\n Press ESC to quit");
            
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