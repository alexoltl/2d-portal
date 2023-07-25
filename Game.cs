using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public static RenderWindow window;
    public static float deltaTime;
    public const float gravity = 0.06f;  
    public static Vector2f playerSize = new Vector2f(30, 30);
    public static Vector2f portalSize = new Vector2f(10, 70);
    public static Portal bluePortal;
    public static Portal orangePortal;
    private Player player;

    public void Run()
    {
        window = new RenderWindow(new VideoMode(600, 600), "the cake piece is real!!!");
        window.SetFramerateLimit(60);

        Clock deltaTimeClock = new Clock();

        player = new Player(new Vector2f(20, 400), playerSize, 0x888888ff);
        bluePortal = new Portal(new Vector2f(50, 300), portalSize, PortalColor.Blue);
        orangePortal = new Portal(new Vector2f(550, 300), portalSize, PortalColor.Orange);

        while (window.IsOpen)
        {
            window.DispatchEvents();

            float deltaTime = deltaTimeClock.Restart().AsSeconds();
            Game.deltaTime = deltaTime;

            window.Closed += (sender, e) => window.Close();
            window.Clear(Color.Black);

            player.Movement();
            window.Draw(Player.rect);

            bluePortal.Collision();
            orangePortal.Collision();
            window.Draw(bluePortal.rect);
            window.Draw(orangePortal.rect);
            
            window.Display();
        }
    }
}