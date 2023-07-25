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
        if (rect.GetGlobalBounds().Intersects(Player.rect.GetGlobalBounds()))
        {
            if (portalType == PortalColor.Orange)
            {
                Player.rect.Position = Game.bluePortal.rect.Position;
            }
            else if (portalType == PortalColor.Blue)
            {
                Player.rect.Position = Game.orangePortal.rect.Position;
            }
        }
    }
}

enum PortalColor
{
    Orange,
    Blue
}
