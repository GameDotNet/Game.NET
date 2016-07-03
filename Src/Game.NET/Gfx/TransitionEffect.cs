using Game.NET.Core;
using Game.NET.Logic;

namespace Game.NET
{
    public abstract class TransitionEffect
    {
        public bool bReversed;
        protected bool bFinished;
        public bool IsFinished
        {
            get
            {
                return bFinished;
            }
        }

        public abstract void Update(GameTime gameTime, float speed = 1.0f);
        public abstract void Draw(State state);
    }
}