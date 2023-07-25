using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public static RenderWindow window;
    public static float deltaTime;
    public const float gravity = 0.06f;  
    public static Vector2f playerSize = new Vector2f(30, 30);
    private static Player player;

    public void Run()
    {
        window = new RenderWindow(new VideoMode(600, 600), "portal cheap");
        window.SetFramerateLimit(60);

        Clock deltaTimeClock = new Clock();

        Map map = new Map();
        int tileSize = (int)Game.window.Size.X / Map.mapDimensions;

        player = new Player(new Vector2f(20, 400), playerSize, 0x888888ff);

        while (window.IsOpen)
        {
            window.DispatchEvents();

            float deltaTime = deltaTimeClock.Restart().AsSeconds();
            Game.deltaTime = deltaTime;

            window.Closed += (sender, e) => window.Close();
            window.Clear(Color.Black);

            Map.Create();

            for (int i = 0; i < Map.tileList.Count; i++)
            {
                window.Draw(Map.tileList[i]);
            }

            player.Movement();
            window.Draw(Player.rect);

            Map.bluePortal.Collision();
            Map.orangePortal.Collision();
            window.Draw(Map.bluePortal.rect);
            window.Draw(Map.orangePortal.rect);
            
            window.Display();
        }
    }
}