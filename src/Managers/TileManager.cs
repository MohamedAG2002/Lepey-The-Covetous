using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TiledSharp;

using System;

namespace LepeyTheCovetous;

public class TileManager
{
    private TmxMap _map;
    private Texture2D _forestTileset, _objectsTileset;
    private Vector2 _forestTilesSize, _objectsTilesSize;
    private Vector2 _forestTilsetTilesSize, _objectsTilesetTilesSize;

    public TileManager()
    {
        _map = AssetManager.Instance().GetMap();
        _forestTileset = AssetManager.Instance().GetTile("Tileset");
        _objectsTileset = AssetManager.Instance().GetTile("Objects");

        _forestTilesSize = new Vector2(_map.Tilesets[0].TileWidth, _map.Tilesets[0].TileHeight);
        _objectsTilesSize = new Vector2(_map.Tilesets[1].TileWidth, _map.Tilesets[1].TileHeight);

        _forestTilsetTilesSize = new Vector2(_forestTileset.Width / _forestTilesSize.X, _forestTileset.Height / _forestTilesSize.Y);
        _objectsTilesetTilesSize = new Vector2(_objectsTileset.Width / _objectsTilesSize.X, _objectsTileset.Height / _objectsTilesSize.Y);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Rendering each layer
        for(int i = 0; i < _map.Layers.Count; i++)
        {
            for(int j = 0; j < _map.Layers[i].Tiles.Count; j++)
            {
                int gid = _map.Layers[i].Tiles[j].Gid;

                Texture2D tilset;
                Vector2 tileSize, tilesetTilesSize;

                // Picking the tileset and the sizes depending on the layer
                if(i == 0) 
                {
                    tilset = _forestTileset;
                    tileSize = _forestTilesSize;
                    tilesetTilesSize = _forestTilsetTilesSize;
                }
                else
                {
                    tilset = _objectsTileset;
                    tileSize = _objectsTilesSize;
                    tilesetTilesSize = _objectsTilesetTilesSize;
                }

                // Skip over empty tiles and render the populated tiles
                if(gid != 0)
                {
                    int tileFrame = gid - 1;
                    
                    // Getting the exact column and row of the tile
                    int column = tileFrame % (int)tilesetTilesSize.X;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesSize.X);

                    // Getting the exact position of the tile
                    float x = (j % _map.Width) * _map.TileWidth;
                    float y = (float)Math.Floor(j / (double)_map.Width) * _map.TileHeight;

                    // Setting the rec for rendering
                    Rectangle tilesetRec = new Rectangle((int)tileSize.X * column, 
                                                        (int)tileSize.Y * row, 
                                                        (int)tileSize.X, 
                                                        (int)tileSize.Y);

                    // Drawing the tiles
                    spriteBatch.Draw(tilset, 
                                     new Rectangle((int)x, (int)y, (int)tileSize.X, (int)tileSize.Y), 
                                     tilesetRec, 
                                     Color.White);
                }
            }
        }
    }
}