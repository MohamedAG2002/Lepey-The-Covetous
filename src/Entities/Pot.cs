using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Pot : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public SpriteComponent Sprite {get; set;}
    public ColliderComponent Collider {get; set;}

    public delegate void ScoreIncrease();
    public static event ScoreIncrease ScoreIncreaseEvent;

    private Player _player;
    private Vector2 _playerPosOffset;

    public Pot(Player player)
    {
        IsAlive = true;

        _player = player;
        _playerPosOffset = new Vector2(0.0f, 20.0f);

        Transform = new TransformComponent(_player.Transform.Position - _playerPosOffset);
        Sprite = new SpriteComponent(AssetManager.Instance().GetSprite("Pot"), Color.White);
        Collider = new ColliderComponent(Sprite.Texture, Transform.Position);
    }

    public override void Update(GameTime gameTime)
    {
        Transform.Update(gameTime);
        Collider.Update(gameTime);

        Transform.Position = _player.Transform.Position - _playerPosOffset;
    }

    public override void CollisionUpdate(List<IEntity> entities)
    {
        foreach(var entity in entities)
        {
            // Only checks for coins(not itself, nor the player)
            if(entity is Coin)
            {
                if(Collider.IsCollding((entity as Coin).Collider.Collider))
                {
                    // Remove the coin


                    // Increase the score
                }
            }
        }
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        if(IsAlive)
            Sprite.Render(spriteBatch, Transform.Position);
    }
}