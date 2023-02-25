using Microsoft.Xna.Framework;

using System;

namespace LepeyTheCovetous;

public class TransformComponent : IUpdateComponent
{
    public Vector2 Position {get; set;}

    public TransformComponent(Vector2 position)
    {
        Position = position;
    }

    public void Update(GameTime gameTime)
    {
        // Clamps the entity's position to stay inside the window borders
        Position = new Vector2(MathHelper.Clamp(Position.X, 0.0f, Game1.ScreenWidth - 32.0f), Position.Y);
    }

    // Moves the position by a given offset
    public void MovePosition(Vector2 offset)
    {
        Position += offset;
    }
}