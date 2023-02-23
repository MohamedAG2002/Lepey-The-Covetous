using Microsoft.Xna.Framework;

namespace LepeyTheCovetous;

public class ScoreManager
{
    public int Score, HighScore;

    public ScoreManager()
    {
        Score = 0;
        HighScore = 0;
    }

    public void Update()
    {
        // Setting the high score if a new one was set
        HighScore = Score > HighScore ? Score : HighScore;
    }

    public void OnScoreChange()
    {
        Score++;
    }
}