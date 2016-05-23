using Game.NET.Logic;

namespace Game.NET.Core
{
    public class Engine
    {
        public GameTime Time { get; private set; }

        public State CurrentState { get; private set; }

        public bool IsDone { get; private set; }

        public Engine()
        {
            IsDone = true;
        }

        public bool Init(string[] argv = null, string config = "Config.cfg")
        {
            IsDone = false;
            return true;
        }

        public void SwitchState(State state)
        {
            if (CurrentState != null) CurrentState.End();

            CurrentState = state;

            if (CurrentState != null) CurrentState.Start();
        }

        public void CleanUp()
        {
            IsDone = true;
        }
    }
}
