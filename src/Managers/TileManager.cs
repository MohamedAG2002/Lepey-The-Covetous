using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using LDtk;
using LDtk.Renderer;

namespace LepeyTheCovetous;

public class TileManager
{
    private LDtkWorld _world;

    public TileManager() 
    {
        _world = AssetManager.Instance().GetMap();

        // Pre-render the levels
        foreach(var level in _world.Levels)
        {
            Game1.Renderer.PrerenderLevel(level);
        }
    }

    public void Render()
    {
        // Rendering the levels
        foreach(var level in _world.Levels)
        {
            Game1.Renderer.RenderPrerenderedLevel(level);
        }
    }
}