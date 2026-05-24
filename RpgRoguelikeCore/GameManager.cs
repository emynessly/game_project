using System;

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