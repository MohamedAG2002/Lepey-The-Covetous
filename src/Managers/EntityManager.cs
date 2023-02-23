using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace LepeyTheCovetous;

public class EntityManager
{
    public List<IEntity> Entities {get; private set;}

    public EntityManager()
    {

    }

    public void Update(GameTime gameTime)
    {
        // Updating all of the entities
        foreach(var entity in Entities)
        {
            entity.Update(gameTime);
        }
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Rendering all of the entities
        foreach(var entity in Entities)
        {
            entity.Render(spriteBatch);
        }
    }
}