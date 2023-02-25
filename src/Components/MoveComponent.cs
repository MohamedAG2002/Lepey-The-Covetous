using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class MoveComponent : IUpdateComponent
{
    private float _speed;
    public Vector2 Velocity {get; set;}
    public bool IsMoving {get; set;}
    public int Direction {get; private set;}

    public MoveComponent(float speed)
    {
        _speed = speed;

        Velocity = new Vector2(_speed, _speed);
        IsMoving = true;

        // If this number is 0, then the player is moving left, otherwise if it is 1, then the player is moving right
        Direction = 0;
    }

    public void Update(GameTime gameTime)
    {
        if(IsMoving) 
            Move(gameTime);
    }

    public void Move(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Move left
        if(Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            Velocity = new Vector2(-_speed * deltaTime, 0.0f);
            Direction = 0;
        }
        // Move right
        else if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            Velocity = new Vector2(_speed * deltaTime, 0.0f);
            Direction = 1;
        }
        // There is no motion; standing still
        else 
            Velocity = Vector2.Zero;
    }
}