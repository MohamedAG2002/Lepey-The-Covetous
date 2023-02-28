using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class SceneManager
{
    public SceneType Type;
    private IScene _currentScene;
    private bool _isSceneChange;
    private ScoreManager _score;

    public SceneManager()
    {
        Type = SceneType.Menu;
        _currentScene = new MainMenuScene();
        _isSceneChange = false;

        _score = new ScoreManager();

        // Subscribing to events
        MainMenuScene.SceneChangedEvent += OnSceneChanged;
        GameScene.SceneChangedEvent += OnSceneChanged;
        CreditScene.SceneChangedEvent += OnSceneChanged;
        OverScene.SceneChangedEvent += OnSceneChanged;
    }

    public void Update(GameTime gameTime)
    {
        // Only updating the current scene
        _currentScene.Update(gameTime);

        // Only lading the scene when the scene is changed
        if(!_isSceneChange) return;

        // Loading the specific scene depending on the type 
        switch(Type)
        {
            case SceneType.Menu:
                LoadScene(new MainMenuScene());
                break;
            case SceneType.Game:
                LoadScene(new GameScene(_score));
                break;
            case SceneType.Credit:
                LoadScene(new CreditScene());
                break;
            case SceneType.Over:
                LoadScene(new OverScene(_score));
                break;
        }

        // Turning back to false to prevent the re-loading of the scene
        _isSceneChange = false;
    }

    public void Render(SpriteBatch spriteBatch)
    {
        // Only rendering the current scene;
        _currentScene.Render(spriteBatch);
    }

    public void LoadScene(IScene scene)
    {
        _currentScene = scene;   
    }

    public void OnSceneChanged(SceneType sceneToChangeTo)
    {
        // Resetting the score when going to the game since the ScoreManager does not reload with scenes
        if(sceneToChangeTo == SceneType.Game)
            _score.Score = 0;

        Type = sceneToChangeTo;

        _isSceneChange = true;
    }
}