using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Portal
{
    public PortalColor portalType;
    public RectangleShape rect;

    public PortalColor PortalType
    {
        get { return portalType; }
        set
        {
            portalType = value;

            if (portalType == PortalColor.Orange)
            {
                rect.FillColor = new Color(0xffa500ff);
            }
            else if (portalType == PortalColor.Blue)
            {
                rect.FillColor = Color.Blue;
            }
        }
    }

    public Portal(Vector2f position, Vector2f size, PortalColor type)
    {
        rect = new RectangleShape
        {
            Position = position,
            Size = size,
        };

        PortalType = type;
    }

    public void Collision()
{
    FloatRect portalBounds = rect.GetGlobalBounds();
    FloatRect playerBounds = Player.rect.GetGlobalBounds();

    if (portalBounds.Intersects(playerBounds))
    {
        Vector2f portalCenter = new Vector2f(portalBounds.Left + portalBounds.Width / 2f, portalBounds.Top + portalBounds.Height / 2f);
        Vector2f playerCenter = new Vector2f(playerBounds.Left + playerBounds.Width / 2f, playerBounds.Top + playerBounds.Height / 2f);

        if (playerCenter.X < portalCenter.X)
        {
            if (portalType == PortalColor.Orange)
            {
                Vector2f newPosition = Game.bluePortal.rect.Position;
                newPosition.X += Player.rect.Size.X + Game.bluePortal.rect.Size.X;
                Player.rect.Position = newPosition;
            }
            else if (portalType == PortalColor.Blue)
            {
                Vector2f newPosition = Game.orangePortal.rect.Position;
                newPosition.X += Player.rect.Size.X + Game.orangePortal.rect.Size.X;
                Player.rect.Position = newPosition;
            }
        }
        else
        {
            if (portalType == PortalColor.Orange)
            {
                Vector2f newPosition = Game.bluePortal.rect.Position;
                newPosition.X -= Player.rect.Size.X + Game.bluePortal.rect.Size.X;
                Player.rect.Position = newPosition;
            }
            else if (portalType == PortalColor.Blue)
            {
                Vector2f newPosition = Game.orangePortal.rect.Position;
                newPosition.X -= Player.rect.Size.X + Game.orangePortal.rect.Size.X;
                Player.rect.Position = newPosition;
            }
        }
    }
}

}

enum PortalColor
{
    Orange,
    Blue
}
