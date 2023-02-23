using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System.Collections.Generic;

namespace LepeyTheCovetous;

public sealed class AssetManager
{
    private static readonly AssetManager _instance = new AssetManager();
    private Dictionary<string, Texture2D> _spriteDict = new Dictionary<string, Texture2D>();
    private Dictionary<string, Texture2D> _tileDict = new Dictionary<string, Texture2D>();
    private Dictionary<string, SpriteFont> _fontDict = new Dictionary<string, SpriteFont>();

    public AssetManager()
    { }

    // Loading all of the assets
    public void LoadAssets(ContentManager content)
    {
        LoadFonts(content);
        LoadTiles(content);
        LoadSprites(content);
    }

    // Only loading the sprites
    public void LoadSprites(ContentManager content)
    {
        _spriteDict.Add("Background", content.Load<Texture2D>("bg_forest"));
        _spriteDict.Add("Player-Walk-Left", content.Load<Texture2D>("player_walk_left"));
        _spriteDict.Add("Player-Walk-Right", content.Load<Texture2D>("player_walk_right"));
        _spriteDict.Add("Coin", content.Load<Texture2D>("spining_coint"));
    }

    // Only loading the tiles
    public void LoadTiles(ContentManager content)
    {
        _tileDict.Add("Tileset", content.Load<Texture2D>("forest_tileset"));
        _tileDict.Add("Objects", content.Load<Texture2D>("forest_objects_tileset"));
    }

    // Only loading the fonts
    public void LoadFonts(ContentManager content)
    {
        _fontDict.Add("Large", content.Load<SpriteFont>("large"));
        _fontDict.Add("Medium", content.Load<SpriteFont>("medium"));
        _fontDict.Add("Small", content.Load<SpriteFont>("small"));
    }

    // Loads a specific sprite
    public Texture2D GetSprite(string spriteName)
    {
        return _spriteDict[spriteName];
    }

    // Loads a specific tile
    public Texture2D GetTile(string tileName)
    {
        return _tileDict[tileName];
    }

    // Loads a specfic font
    public SpriteFont GetFont(string fontName)
    {
        return _fontDict[fontName];
    }
}