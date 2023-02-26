using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace LepeyTheCovetous;

public class AudioManager
{
    public float Volume {get; set;}
    public float Pitch {get; set;}
    public float Pan {get; set;}

    public AudioManager()
    {
        Volume = 0.5f;
        Pitch = 0.0f;
        Pan = 0.0f;

        // Subscribing to events
        Pot.CoinAudioEvent += OnCoinCollect;
        Coin.CoinAudioEvent += OnGameOver;
    }

    public void OnCoinCollect()
    {
        AssetManager.Instance().GetAudio("Coin-Clicker").Play(Volume, Pitch, Pan);
    }

    public void OnGameOver()
    {
        AssetManager.Instance().GetAudio("Coin-Splash").Play(Volume, Pitch, Pan);
    }
}