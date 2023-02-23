using Microsoft.Xna.Framework;

using System;

namespace LepeyTheCovetous;

public class TransformComponent : IUpdateComponent
{
    public Vector2 Position {get; set;}
    public float Rotation {get; set;}
    public Vector2 Scale {get; set;}

    public TransformComponent(Vector2 position, float rotation, Vector2 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }

    public void Update(GameTime gameTime)
    {
        
    }

    // Moves the position by a given offset
    public void MovePosition(Vector2 offset)
    {
        Position += offset;
    }

    // Rotates by initially given rotation
    public void Rotate()
    {
        Position = new Vector2(MathF.Cos(Rotation), MathF.Sin(Rotation));
    }

    public void ScaleUp(Vector2 factor)
    {
        Scale += factor;
    }

    public void ScaleDown(Vector2 factor)
    {
        Scale -= factor;
    }
}