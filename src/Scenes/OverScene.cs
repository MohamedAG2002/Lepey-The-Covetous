using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class OverScene : IScene
{
    private string _title, _scoreText, _highScoreText;
    private string _replayText, _toMenuText;

    public OverScene()
    {
        _title = "GAME OVER";
        _scoreText = "SCORE: ";
        _highScoreText = "HIGH SCORE: ";
        _replayText = "[R] REPLAY";
        _toMenuText = "[M] MENU";
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Title render

        // Score text render

        // High score text render

        // Replay text render

        // To menu text render
    }
}