using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Pot : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public SpriteComponent Sprite {get; set;}

    private Player _player;
    private Vector2 _playerPosOffset;

    public Pot(Player player)
    {
        IsAlive = true;

        _player = player;
        _playerPosOffset = new Vector2(0.0f, 20.0f);

        Transform = new TransformComponent(_player.Transform.Position - _playerPosOffset);
        Sprite = new SpriteComponent(AssetManager.Instance().GetSprite("Pot"), Color.White);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);

        Transform.Position = _player.Transform.Position - _playerPosOffset;
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Sprite.Render(spriteBatch, Transform.Position);
    }
}