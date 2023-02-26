using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Coin : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public AnimatorComponent Animator;
    public ColliderComponent Collider {get; set;}

    public delegate void CoinEvent();
    public static event CoinEvent CointOutOfRange;

    public Coin(Vector2 position)
    {
        IsAlive = true;

        Transform = new TransformComponent(position);
        Animator = new AnimatorComponent(AssetManager.Instance().GetSprite("Coin"), 8, 5);
        Collider = new ColliderComponent(Animator.Animation, Transform.Position);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
        Animator.Update(gameTime);
        Collider.Update(gameTime);

        // Constantly decending
        Transform.MovePosition(new Vector2(0.0f, 200.0f * (float)gameTime.ElapsedGameTime.TotalSeconds));

        // Triggering an event when a coin leaves the screen's borders
        if(Transform.Position.Y > Game1.ScreenHeight)
            CointOutOfRange?.Invoke();
    }

    public override void CollisionUpdate(List<IEntity> entities)
    {
        // Does nothing here...
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Animator.Render(spriteBatch, Transform.Position);
    }
}