using System.Collections.Generic;
using Game.NET.Core;
using Game.NET.Gfx;

namespace Game.NET.Logic
{
    public abstract class State
    {
        protected Engine _engine;
        protected List<Entity> Entities = new List<Entity>();

        public State(Engine engine)
        {
            _engine = engine;
        }
        
        public abstract void Start();

        public abstract void End();

        public abstract void Update(GameTime gameTime);

        public abstract void ProcessInput();

        public abstract void CleanUp();

        public abstract void Draw(Renderer renderer, GameTime time);
    }
}
