using Microsoft.Xna.Framework;

namespace LepeyTheCovetous;

public class SpawnManager
{
    private EntityManager _entities;
    private Vector2 _position;
    private float _timer, _maxTime;

    public SpawnManager(EntityManager entityManager)
    {
        _entities = entityManager;

        _position = new Vector2(32.0f, 0.0f);

        _timer = 0.0f;
        _maxTime = 20.0f;
    }

    public void Update(GameTime gameTime)
    {
        // Ticking the timer
        _timer++;

        // Spawns a coin every fixed amount of time
        if(_timer >= _maxTime)
        {
            _timer = 0;

            // Adding a new coin
            _entities.Entities.Add(new Coin(_position));

            // Picks a new random position
            _position = new Vector2((float)Game1.Random.Next(0, Game1.ScreenWidth - 16), 0.0f);
        }
    }
}