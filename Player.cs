using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player
{
    public RectangleShape rect;
    private float moveForce = 2700f;
    private float mass = 50f;
    private Vector2f velocity;
    private float friction = 0.1f;
    private float jumpForce = 100f;
    public Player(Vector2f position, Vector2f size, uint fillColor)
    {
        rect = new RectangleShape
        {
            Position = position,
            Size = size,
            FillColor = new Color(fillColor)
        };
    }
    public void Movement()
    {
        Vector2f newPosition = rect.Position;
        float movement = (moveForce / mass) * Game.deltaTime;

        if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) velocity.X -= movement;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) velocity.X += movement;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) velocity.Y += jumpForce;

        velocity.X -= friction * velocity.X;
        if (Math.Abs(velocity.X) < 0.1f) velocity.X = 0f;

        newPosition += velocity;
        rect.Position = newPosition;
    }
}