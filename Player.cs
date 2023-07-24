using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player
{
    public static RectangleShape rect;
    private const float moveForce = 90000f;
    private const float mass = 20f;
    private const float gravity = 1000f;
    private Vector2f velocity;
    private const float friction = 0.1f;
    private const float jumpForce = 500f;
    private bool canJump = true;
    private bool isJumping = false;
    private const float groundHeight = 450f;
    private const float maxJumpTime = 0.2f;
    private float currentJumpTime = 0f;

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

        velocity.X -= friction * velocity.X;
        if (Math.Abs(velocity.X) < 0.1f) velocity.X = 0f;

        velocity.Y += gravity * Game.deltaTime;

        newPosition += velocity * Game.deltaTime;

        if (newPosition.Y + rect.Size.Y >= groundHeight)
        {
            newPosition.Y = groundHeight - rect.Size.Y;
            velocity.Y = 0;
            canJump = true;
        }

        if (newPosition.X < 0) newPosition.X = 0;
        if (newPosition.X > Game.window.Size.X - Game.playerSize.X) newPosition.X = Game.window.Size.X - Game.playerSize.X;

        rect.Position = newPosition;

        Jump();
    }



    private void Jump()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
        {
            if (canJump)
            {
                isJumping = true;
                canJump = false;
            }
        }

        if (isJumping)
        {
            if (currentJumpTime < maxJumpTime)
            {
                velocity.Y = -jumpForce;
                currentJumpTime += Game.deltaTime;
            }
            else
            {
                isJumping = false;
                currentJumpTime = 0f;
            }
        }
        else
        {
            currentJumpTime = 0f;
        }
    }

}