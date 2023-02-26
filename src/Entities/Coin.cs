using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Coin : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public AnimatorComponent Animator;

    public Coin(Vector2 position)
    {
        IsAlive = true;

        Transform = new TransformComponent(position);
        Animator = new AnimatorComponent(AssetManager.Instance().GetSprite("Coin"), 8, 10);
    }

    public override void Update(GameTime gameTime)
    {
        // Constantly decending
        Transform.MovePosition(new Vector2(0.0f, 200.0f));
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Animator.Render(spriteBatch, Transform.Position);
    }
}