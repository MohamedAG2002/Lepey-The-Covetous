using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Player : IEntity
{
    public override bool IsAlive {get; set;}
    public TransformComponent Transform;
    public SpriteComponent Sprite;

    public Player()
    {
        IsAlive = true;

        Transform = new TransformComponent(new Vector2(100.0f, 100.0f), 0.0f, Vector2.One);
        Sprite = new SpriteComponent(AssetManager.Instance().GetSprite("Player-Walk-Right"), Color.White, Transform);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Sprite.Render(spriteBatch);
    }
}