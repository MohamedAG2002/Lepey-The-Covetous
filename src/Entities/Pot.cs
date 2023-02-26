using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class Pot : IEntity
{
    public override bool IsAlive {get; set;}
    public override TransformComponent Transform {get; set;}
    public SpriteComponent Sprite {get; set;}
    public Rectangle Collider 
    {
        get {return new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, Sprite.Texture.Width, Sprite.Texture.Height);}
        set {Collider = value;}
    }

    public delegate void ScoreIncrease();
    public delegate void CoinAudio();
    public static event ScoreIncrease ScoreIncreaseEvent;
    public static event CoinAudio CoinAudioEvent;

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

    public override void CollisionUpdate(List<IEntity> entities)
    {
        foreach(var entity in entities)
        {
            // Only checks for coins(not itself, nor the player)
            if(entity is Coin)
            {
                if(Collider.Intersects((entity as Coin).Collider))
                {
                    // Remove the coin
                    entity.IsAlive = false;

                    // Play the appropriate sound
                    CoinAudioEvent?.Invoke();

                    // Increase the score
                    ScoreIncreaseEvent?.Invoke();
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