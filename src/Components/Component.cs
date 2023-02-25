using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public interface IUpdateComponent
{
    public void Update(GameTime gameTime);
}

public interface IRenderComponent
{
    public void Render(SpriteBatch spriteBatch, Vector2 position);
}