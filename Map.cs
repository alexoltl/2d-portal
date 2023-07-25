using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Map
{
    public const int mapDimensions = 20;
    public static int[,] tileMap;
    private static int tileSize;
    public static List<Sprite> tileList = new List<Sprite>();
    public static Portal bluePortal;
    public static Portal orangePortal;
    private static Texture groundTexture = new Texture("gorund.png");

    public static void Create()
    {
        tileMap = new int[mapDimensions, mapDimensions];
        tileSize = (int)Game.window.Size.X / mapDimensions;

        using (StreamReader streamReader = new StreamReader("map.txt"))
        {
            for (int y = 0; y < mapDimensions; y++)
            {
                string line = streamReader.ReadLine();

                for (int x = 0; x < mapDimensions; x++)
                {
                    char tile = line[x];
                    if (char.IsDigit(tile))
                    {
                        tileMap[x, y] = int.Parse(tile.ToString());
                    }
                }
            }
        }

        RenderList();
    }

    public static void RenderList()
    {
        for (int x = 0; x < mapDimensions; x++)
        {
            for (int y = 0; y < mapDimensions; y++)
            {
                int currentTile = tileMap[x,y];
                float xPos = x * tileSize;
                float yPos = y * tileSize;

                if (currentTile == 1)
                {
                    Sprite newTile = new Sprite(groundTexture);
                    newTile.Position = new Vector2f(xPos, yPos);
                    tileList.Add(newTile);
                }
                else if (currentTile == 2)
                {
                    bluePortal = new Portal(new Vector2f(xPos, yPos), new Vector2f(tileSize, tileSize), PortalColor.Blue);
                }
                else if (currentTile == 3)
                {
                    orangePortal = new Portal(new Vector2f(xPos, yPos), new Vector2f(tileSize, tileSize), PortalColor.Orange);
                }
            }
        }
    }
}