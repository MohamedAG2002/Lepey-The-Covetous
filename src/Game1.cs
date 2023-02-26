using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using LDtk.Renderer;

using System;

namespace LepeyTheCovetous;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public static readonly int ScreenWidth = 512;
    public static readonly int ScreenHeight = 480;
    public static Random Random;
    public static LDtkRenderer Renderer;

    #region Managers
    private SceneManager _scenes;
    private AudioManager _audio;
    #endregion

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Random = new Random();

        // Changing the screen resolution
        _graphics.PreferredBackBufferWidth = ScreenWidth;
        _graphics.PreferredBackBufferHeight = ScreenHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Renderer = new LDtkRenderer(_spriteBatch);
        
        #region Managers init
        AssetManager.Instance().LoadAssets(Content);
        _scenes = new SceneManager();
        _audio = new AudioManager();
        #endregion
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        #region Managers update
        _scenes.Update(gameTime);
        #endregion

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Drawing stuff here
        _spriteBatch.Begin();

        // Rendering the background
        _spriteBatch.Draw(AssetManager.Instance().GetSprite("Background"), Vector2.Zero, Color.White);

        #region Managers render
        _scenes.Render(_spriteBatch);
        #endregion

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public static Vector2 CenterText(SpriteFont font, string text)
    {
        return new Vector2(ScreenWidth / 2 - font.MeasureString(text).X / 2,
                           ScreenHeight / 2 - font.MeasureString(text).Y / 2);
    }
}
