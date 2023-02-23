using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class SpriteComponent : IRenderComponent
{
    public Texture2D Texture {get; set;}
    public Color Tint {get; set;}
    public bool IsRenderable {get; set;}

    private TransformComponent _transform;

    public SpriteComponent(Texture2D texture, Color tint, TransformComponent transform)
    {
        Texture = texture;
        Tint = tint;
        IsRenderable = true;

        _transform = transform;
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Renders only is able
        if(IsRenderable)
        {
            spriteBatch.Draw(Texture, 
                            _transform.Position, 
                            null, 
                            Tint,
                            _transform.Rotation, 
                            Vector2.Zero, 
                            _transform.Scale, 
                            SpriteEffects.None,
                            1.0f);
        }
    }
}