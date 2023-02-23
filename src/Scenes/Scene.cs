using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public interface IScene
{
    public void Render(SpriteBatch spriteBatch);
    public void Update(GameTime gameTime);
}