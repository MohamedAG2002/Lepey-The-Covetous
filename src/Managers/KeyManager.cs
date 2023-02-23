using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LepeyTheCovetous;

public class KeyManager
{
    private static KeyboardState _currentState, _previousState;
    private static KeyManager _state = new KeyManager();

    private KeyManager()
    {}

    public static KeyManager GetState()
    {
        _previousState = _currentState;
        _currentState = Keyboard.GetState();

        return _state;
    }

    public bool IsKeyPressed(Keys key)
    {
        return _currentState.IsKeyDown(key) && _previousState.IsKeyUp(key);
    }
}