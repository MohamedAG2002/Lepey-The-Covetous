using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class SceneManager
{
    public SceneType Type;
    private IScene _currentScene;
    private bool _isSceneChange;

    public SceneManager()
    {
        Type = SceneType.Over;

        _currentScene = new OverScene();

        _isSceneChange = false;

        // Subscribing to events
        MainMenuScene.SceneChangedEvent += OnSceneChanged;
        GameScene.SceneChangedEvent += OnSceneChanged;
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
                LoadScene(new GameScene());
                break;
            case SceneType.Over:
                LoadScene(new OverScene());
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
        Type = sceneToChangeTo;

        _isSceneChange = true;
    }
}