using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class ColliderComponent : IUpdateComponent
{
    public Rectangle Collider {get; set;}

    public ColliderComponent(Texture2D texture, Vector2 position)
    {
        Collider = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
    }

    public void Update(GameTime gameTime)
    {

    }

    public bool IsCollding(Rectangle collider)
    {
        return Collider.Intersects(collider);
    }
}