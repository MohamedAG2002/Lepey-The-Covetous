using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace LepeyTheCovetous;

public abstract class IEntity
{
    public abstract TransformComponent Transform {get; set;}
    public abstract bool IsAlive {get; set;}

    public abstract void Render(SpriteBatch spriteBatch);
    public abstract void Update(GameTime gameTime);
    public abstract void CollisionUpdate(List<IEntity> entities);
}