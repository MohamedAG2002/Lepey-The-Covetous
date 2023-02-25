using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class SpriteComponent : IRenderComponent
{
    public Texture2D Texture {get; set;}
    public Color Tint {get; set;}

    public SpriteComponent(Texture2D texture, Color tint)
    {
        Texture = texture;
        Tint = tint;
    }

    public void Render(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(Texture, position, Tint);
    }
}