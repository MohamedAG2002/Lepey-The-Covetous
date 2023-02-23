using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class GameScene :IScene
{
    private ScoreManager _score;
    private bool _isPaused;
    private string _scoreText, _pauseText, _resumeText, _toMenuText;

    public delegate void SceneTransition(SceneType type);
    public static event SceneTransition SceneChangedEvent;

    public GameScene(ScoreManager score)
    {
        _score = score;

        _isPaused = false;

        _scoreText = "SCORE: ";
        _pauseText = "PAUSED";
        _resumeText = "[R] RESUME";
        _toMenuText = "[M] MENU";
    }

    public void Update(GameTime gameTime)
    {
        // Toggling the pause menu
        if(KeyManager.GetState().IsKeyPressed(Keys.P))
            _isPaused = !_isPaused;

        // Only updating all of the below when not paused
        if(_isPaused) return;

        // Score update
        _scoreText = "SCORE: " + _score.Score;
        _score.Update();

        // Entities update
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Drawing the entities

        // Drawing the UI
        SpriteFont smallFont = AssetManager.Instance().GetFont("Small");
        spriteBatch.DrawString(smallFont, _scoreText, new Vector2(Game1.CenterText(smallFont, _scoreText).X, 10.0f), Color.Green);

        // Drawing the pause menu(only when paused)
        if(_isPaused)
            DrawPauseMenu(spriteBatch);
    }

    private void DrawPauseMenu(SpriteBatch spriteBatch)
    {
        SpriteFont largeFont = AssetManager.Instance().GetFont("Large");
        SpriteFont mediumFont = AssetManager.Instance().GetFont("Medium");

        // Pause text render
        spriteBatch.DrawString(largeFont, _pauseText, Game1.CenterText(largeFont, _pauseText) - new Vector2(0.0f, 50.0f), Color.LimeGreen);

        // Resume text render
        spriteBatch.DrawString(mediumFont, _resumeText, Game1.CenterText(mediumFont, _resumeText), Color.LimeGreen);

        // To menu text render
        spriteBatch.DrawString(mediumFont, _toMenuText, Game1.CenterText(mediumFont, _toMenuText) + new Vector2(0.0f, 40.0f), Color.LimeGreen);
    }
}