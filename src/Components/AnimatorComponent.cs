using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LepeyTheCovetous;

public class AnimatorComponent : IRenderComponent, IUpdateComponent
{
    public Texture2D Animation {get; set;}
    public int Frames {get; set;}
    public Vector2 FrameSize {get; set;}
    public int AnimationSpeed {get; set;}

    private int _currentFrame, _timer, _animationDirection;
    private bool _isAnimating;

    public AnimatorComponent(Texture2D animation, int frames, int animationSpeed)
    {
        Animation = animation;
        Frames = frames;
        AnimationSpeed = animationSpeed;
        
        FrameSize = new Vector2(Animation.Width / Frames, Animation.Height);

        _currentFrame = 0;
        _timer = 0;

        // If this number is 1, then the animation is going forwards, otherwise if it is -1, then it is animating backwards
        _animationDirection = 1;

        _isAnimating = true;
    }

    public void Update(GameTime gameTime)
    {
        // Rewinding the animation once it reached it end
        if(_currentFrame >= Frames - 1) _animationDirection = -1;
        else if(_currentFrame == 0) _animationDirection = 1;

        // Only animating when allowed to
        if(!_isAnimating) return;

        _timer++;

        // Animates at a fixed speed
        if(_timer >= AnimationSpeed)
        {
            _timer = 0;
            _currentFrame += _animationDirection;
        }
    }

    public void Render(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle destRec = new Rectangle((_currentFrame * (int)FrameSize.X), 0, (int)FrameSize.X, (int)FrameSize.Y);

        spriteBatch.Draw(Animation, position, destRec, Color.White);
    }

    public void ChangeAnimation(Texture2D texture)
    {
        Animation = texture;

        // Recalculating the size
        FrameSize = new Vector2(texture.Width / Frames, texture.Height);
    }

    public void Play()
    {
        _isAnimating = true;
    }

    public void Stop()
    {
        _isAnimating = false;
    }
}