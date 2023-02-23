using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace LepeyTheCovetous;

public class EntityManager
{
    public List<IEntity> Entities {get; private set;}

    public EntityManager()
    {
        Entities = new List<IEntity>();

        /* Adding entities */
        // Player
        Entities.Add(new Player());
    }

    public void Update(GameTime gameTime)
    {
        // Deleting any entity that is inactive
        for(int i = 0; i < Entities.Count; i++)
        {
            if(!Entities[i].IsAlive)
            {
                Entities.RemoveAt(i);
                i--;
            }
        }

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