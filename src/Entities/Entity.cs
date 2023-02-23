using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public interface IEntity
{
    public void Render(SpriteBatch spriteBatch);
    public void Update(GameTime gameTime);
}