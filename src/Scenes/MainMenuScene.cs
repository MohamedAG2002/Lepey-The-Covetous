using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class MainMenuScene : IScene
{
    private string _title, _playText;

    public delegate void SceneTransition(SceneType type);
    public static event SceneTransition SceneChangedEvent;

    public MainMenuScene()
    {
        _title = "Lepey The Covetous";
        _playText = "[ENTER] PLAY";
    }

    public void Update(GameTime gameTime)
    {
        // TRANSITION: Menu to Game
        if(KeyManager.GetState().IsKeyPressed(Keys.Enter))
            SceneChangedEvent?.Invoke(SceneType.Game);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        SpriteFont largeFont = AssetManager.Instance().GetFont("Large");
        SpriteFont mediumFont = AssetManager.Instance().GetFont("Medium");

        // Title render
        spriteBatch.DrawString(largeFont, _title, new Vector2(Game1.CenterText(largeFont, _playText).X - 75.0f, 15.0f), Color.Green);

        // Play text render
        spriteBatch.DrawString(mediumFont, _playText, Game1.CenterText(mediumFont, _playText) - new Vector2(0.0f, 25.0f), Color.Green);
    }
}