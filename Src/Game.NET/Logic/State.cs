using Game.NET.Core;

namespace Game.NET.Logic
{
    public abstract class State
    {
        protected Engine _engine;

        public State(Engine engine)
        {
            _engine = engine;
        }
        
        public abstract void Start();

        public abstract void End();

        public abstract void Update(GameTime gameTime);

        public abstract void ProcessInput();

        public abstract void CleanUp();
    }
}
