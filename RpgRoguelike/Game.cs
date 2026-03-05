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
                instance.Init();
            }
            return instance;
        }
    }

    private void Init()
    {
        gameStopped = false;
        Console.Clear();
        Console.WriteLine("Game is running... Press Escape to stop.");
    }
    public void Run()
    {
        Console.Clear();
        Console.WriteLine($"Game Started with difficulty: {Difficulty}");

        while (!GameIsEnded())
        {
            HandleInput();
            Update();
            Render();
        }
    }

    private bool GameIsEnded()
    {
        return gameStopped;
    }

    private void HandleInput()
    {
        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Escape)
            gameStopped = true;
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

    private bool gameStopped = false;
    private static Game? instance;
}
