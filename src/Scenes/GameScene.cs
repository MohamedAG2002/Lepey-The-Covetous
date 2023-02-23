using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class GameScene :IScene
{
    private string _scoreText;

    public GameScene()
    {
        _scoreText = "SCORE:";
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Render(SpriteBatch spriteBatch)
    {


        // Drawing the UI
        SpriteFont smallFont = AssetManager.Instance().GetFont("Small");
        spriteBatch.DrawString(smallFont, _scoreText, new Vector2(Game1.CenterText(smallFont, _scoreText).X, 10.0f), Color.Green);
    }
}