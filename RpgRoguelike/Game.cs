namespace RpgRoguelike;

public class Game
{
    public void Init()
    {
        gameStopped = false;
        Console.Clear();
        Console.WriteLine("Game is running... Press Escape to stop.");
    }
    public void Run()
    {
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
        Console.WriteLine("Game is running... Press Escape to end game.");
    }

    private bool gameStopped = false;
}
