using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class MainMenuScene : IScene
{
    private string _title, _playText;

    public MainMenuScene()
    {
        _title = "Lepey The Covetous";
        _playText = "[ENTER] PLAY";
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Render(SpriteBatch spriteBatch)
    {
        SpriteFont largeFont = AssetManager.Instance().GetFont("Large");
        SpriteFont mediumFont = AssetManager.Instance().GetFont("Medium");

        float randOffset = Game1.Random.Next(0, 10);

        // Title render
        spriteBatch.DrawString(largeFont, _title, new Vector2(Game1.CenterText(largeFont, _playText).X - 75.0f, 15.0f + randOffset), Color.Green);

        // Play text render
        spriteBatch.DrawString(mediumFont, _playText, Game1.CenterText(mediumFont, _playText) - new Vector2(0.0f, 25.0f), Color.Green);
    }
}