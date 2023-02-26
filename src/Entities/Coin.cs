using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Coin : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public AnimatorComponent Animator;
    public Rectangle Collider
    {
        // Dividing the width by the frames of the animation to get the true width of the animation(only one frame not the whole animation)
        get {return new Rectangle((int)Transform.Position.X, 
                                  (int)Transform.Position.Y, 
                                  Animator.Animation.Width / Animator.Frames, 
                                  Animator.Animation.Height);}
        set {Collider = value;}
    }

    public delegate void CoinEvent();
    public delegate void CoinAudio();
    public static event CoinEvent CointOutOfRange;
    public static event CoinAudio CoinAudioEvent;

    public Coin(Vector2 position)
    {
        IsAlive = true;

        Transform = new TransformComponent(position);
        Animator = new AnimatorComponent(AssetManager.Instance().GetSprite("Coin"), 8, 5);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
        Animator.Update(gameTime);

        // Constantly decending
        Transform.MovePosition(new Vector2(0.0f, 150.0f * (float)gameTime.ElapsedGameTime.TotalSeconds));

        // Triggering an event when a coin leaves the screen's borders
        if(Transform.Position.Y > Game1.ScreenHeight)
        {
            CoinAudioEvent?.Invoke();
            CointOutOfRange?.Invoke();
        }
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