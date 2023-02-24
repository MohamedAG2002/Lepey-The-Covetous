using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using TiledSharp;

using System.Collections.Generic;

namespace LepeyTheCovetous;

public sealed class AssetManager
{
    private static readonly AssetManager _instance = new AssetManager();
    private Dictionary<string, Texture2D> _spriteDict = new Dictionary<string, Texture2D>();
    private Dictionary<string, Texture2D> _tileDict = new Dictionary<string, Texture2D>();
    private Dictionary<string, SpriteFont> _fontDict = new Dictionary<string, SpriteFont>();
    private TmxMap _map;

    public AssetManager()
    { }

    // Returns the instatnce
    public static AssetManager Instance()
    {
        return _instance;
    }

    // Loading all of the assets
    public void LoadAssets(ContentManager content)
    {
        LoadTiles(content);
        LoadMap(content);
        LoadFonts(content);
        LoadSprites(content);
    }

    // Only loads the map
    public void LoadMap(ContentManager content)
    {
        _map = new TmxMap("./Content/Map/TheCovetousForest.tmx");
    }

    // Only loading the sprites
    public void LoadSprites(ContentManager content)
    {
        _spriteDict.Add("Background", content.Load<Texture2D>("Sprites/bg_forest"));
        _spriteDict.Add("Player-Walk-Left", content.Load<Texture2D>("Sprites/player_walk_left"));
        _spriteDict.Add("Player-Walk-Right", content.Load<Texture2D>("Sprites/player_walk_right"));
        _spriteDict.Add("Coin", content.Load<Texture2D>("Sprites/spining_coin"));
        _spriteDict.Add("Poit", content.Load<Texture2D>("Sprites/pot"));
    }

    // Only loading the tiles
    public void LoadTiles(ContentManager content)
    {
        _tileDict.Add("Tileset", content.Load<Texture2D>("Tiles/forest_tileset"));
        _tileDict.Add("Objects", content.Load<Texture2D>("Tiles/forest_objects"));
    }

    // Only loading the fonts
    public void LoadFonts(ContentManager content)
    {
        _fontDict.Add("Large", content.Load<SpriteFont>("Font/large"));
        _fontDict.Add("Medium", content.Load<SpriteFont>("Font/medium"));
        _fontDict.Add("Small", content.Load<SpriteFont>("Font/small"));
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

    // Loads the map
    public TmxMap GetMap()
    {
        return _map;
    }
}