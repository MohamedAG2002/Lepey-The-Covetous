using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public abstract class IEntity
{
    public abstract bool IsAlive {get; set;}

    public abstract void Render(SpriteBatch spriteBatch);
    public abstract void Update(GameTime gameTime);
}