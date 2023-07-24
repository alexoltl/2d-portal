using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public static RenderWindow window;
    public static float deltaTime;
    public const float gravity = 0.06f;  
    public static Vector2f playerSize = new Vector2f(30, 30);
    private Player player;

    public void Run()
    {
        window = new RenderWindow(new VideoMode(600, 600), "the cake piece is real!!!");
        window.SetFramerateLimit(60);

        Clock deltaTimeClock = new Clock();

        player = new Player(new Vector2f(20, 400), playerSize, 0x888888ff);

        while (window.IsOpen)
        {
            window.DispatchEvents();

            float deltaTime = deltaTimeClock.Restart().AsSeconds();
            Game.deltaTime = deltaTime;

            window.Closed += (sender, e) => window.Close();
            window.Clear(Color.Black);

            player.Movement();
            window.Draw(player.rect);
            
            window.Display();
        }
    }
}