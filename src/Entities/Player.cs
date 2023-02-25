using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Player : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public AnimatorComponent Animator {get; set;}
    public MoveComponent Move;

    public Player()
    {
        IsAlive = true;

        Transform = new TransformComponent(new Vector2(100.0f, Game1.ScreenHeight - 155.0f));
        Animator = new AnimatorComponent(AssetManager.Instance().GetSprite("Player-Walk-Left"), 3, 5);
        Move = new MoveComponent(200.0f);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
        Move.Update(gameTime);

        // Only animating when the player is moving
        if(Move.Velocity.X != 0)
            Animator.Update(gameTime);

        Transform.MovePosition(Move.Velocity);

        // Switching the animation depending on the direction of the player
        if(Move.Direction == 1)
            Animator.Animation = AssetManager.Instance().GetSprite("Player-Walk-Right");
        else 
            Animator.Animation = AssetManager.Instance().GetSprite("Player-Walk-Left");
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Animator.Render(spriteBatch, Transform.Position);
    }
}