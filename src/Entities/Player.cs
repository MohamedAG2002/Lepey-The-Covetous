using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Player : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public SpriteComponent Sprite;
    public MoveComponent Move;

    public Player()
    {
        IsAlive = true;

        Transform = new TransformComponent(new Vector2(100.0f, Game1.ScreenHeight - 155.0f), 0.0f, Vector2.One);
        Sprite = new SpriteComponent(AssetManager.Instance().GetSprite("Player-Walk-Right"), Color.White, Transform);
        Move = new MoveComponent(200.0f);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
        Move.Update(gameTime);

        Transform.MovePosition(Move.Velocity);
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Sprite.Render(spriteBatch);
    }
}