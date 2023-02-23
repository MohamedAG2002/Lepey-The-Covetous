using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class OverScene : IScene
{
    private string _title, _scoreText, _highScoreText;
    private string _replayText, _toMenuText;

    public delegate void SceneTransition(SceneType type);
    public static event SceneTransition SceneChangedEvent;

    public OverScene()
    {
        _title = "GAME OVER";
        _scoreText = "SCORE:";
        _highScoreText = "HIGH SCORE:";
        _replayText = "[R] REPLAY";
        _toMenuText = "[M] MENU";
    }

    public void Update(GameTime gameTime)
    {
        // TRANSITION: Over to Game
        if(KeyManager.GetState().IsKeyPressed(Keys.R))
            SceneChangedEvent?.Invoke(SceneType.Game);
        // TRANSITION: Over to Menu
        else if(KeyManager.GetState().IsKeyPressed(Keys.M))
            SceneChangedEvent?.Invoke(SceneType.Menu);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        SpriteFont largeFont = AssetManager.Instance().GetFont("Large");
        SpriteFont mediumFont = AssetManager.Instance().GetFont("Medium");

        // Title render
        spriteBatch.DrawString(largeFont, _title, new Vector2(Game1.CenterText(largeFont, _title).X, 15.0f), Color.DarkGreen);

        // Score text render

        // High score text render

        // Replay text render

        // To menu text render
    }
}