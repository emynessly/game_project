namespace RpgRoguelikeCore
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class GameSettings
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public Difficulty CurrentDifficulty { get; set; }

        public GameSettings()
        {
            MapWidth = 100;
            MapHeight = 100;
            CurrentDifficulty = Difficulty.Normal;
        }
    }   
}