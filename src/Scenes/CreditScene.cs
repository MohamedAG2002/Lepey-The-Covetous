using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class CreditScene : IScene
{
    private string _title, _toMenuText;

    public delegate void SceneTransition(SceneType type);
    public static event SceneTransition SceneChangedEvent;

    public CreditScene()
    {
        _title = "CREDITS";
        _toMenuText = "[M] MENU";
    }

    public void Update(GameTime gameTime)
    {
        // TRANSITION: Credits to Menu
        if(KeyManager.GetState().IsKeyPressed(Keys.M))
            SceneChangedEvent?.Invoke(SceneType.Menu);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        SpriteFont largeFont = AssetManager.Instance().GetFont("Large");
        SpriteFont mediumFont = AssetManager.Instance().GetFont("Medium");

        // Tile render
        spriteBatch.DrawString(largeFont, _title, new Vector2(Game1.CenterText(largeFont, _title).X, 10.0f), Color.Green);

        // ART:
        spriteBatch.DrawString(mediumFont, "ART:", new Vector2(20.0f, 70.0f), Color.DarkGreen);
        spriteBatch.DrawString(mediumFont, "ZomBCool", new Vector2(20.0f, 100.0f), Color.ForestGreen);
        spriteBatch.DrawString(mediumFont, "Puddin", new Vector2(20.0f, 130.0f), Color.ForestGreen);
        spriteBatch.DrawString(mediumFont, "Lucas Neves", new Vector2(20.0f, 160.0f), Color.ForestGreen);

        // AUDIO:
        spriteBatch.DrawString(mediumFont, "AUDIO:", new Vector2(20.0f, 200.0f), Color.DarkGreen);
        spriteBatch.DrawString(mediumFont, "Varkalandar", new Vector2(20.0f, 230.0f), Color.ForestGreen);
        spriteBatch.DrawString(mediumFont, "LordTomorrow", new Vector2(20.0f, 260.0f), Color.ForestGreen);
        spriteBatch.DrawString(mediumFont, "Matthew Pablo", new Vector2(20.0f, 290.0f), Color.ForestGreen);

        // To menu text render
        spriteBatch.DrawString(mediumFont, _toMenuText, new Vector2(Game1.CenterText(mediumFont, _toMenuText).X, 360.0f), Color.Green);
    }
}