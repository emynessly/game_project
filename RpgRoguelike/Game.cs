namespace RpgRoguelike;

public class Game
{
    public int MapWidth{ get; private set; } = 100;
    public int MapHeight { get; private set; } = 100;
    public string Difficulty { get; private set; } = "Normal";

    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
    }

    private void Update()
    {
        // Now empty, no game logic for now.
    }

    private void Render()
    {
        Console.Clear();
        Console.WriteLine($"Game is running (Difficulty: {Difficulty})... Press Escape to end game.");
        Console.WriteLine($"Map size: {MapWidth} x {MapHeight}");
    }

    private static Game? instance;
}
