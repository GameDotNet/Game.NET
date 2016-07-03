using Game.NET.Core;
using Game.NET.Gfx;

namespace Game.NET.Logic
{
    public class Transition : State
    {
        public State InitialState { get; private set; }
        public State TargetState { get; private set; }

        public float OutSpeed = 1.0f;
        public float InSpeed = 1.0f;

        public TransitionEffect Out;
        public TransitionEffect In;

        private bool _oldState;

        public delegate void SimpleAction();
        public event SimpleAction OnStart;
        public event SimpleAction OnEnd;
        public event SimpleAction OnHalf;

        public Transition(Engine framework, State from, State to)
            : base(framework)
        {
            InitialState = from;
            TargetState = to;
        }

        #region implemented abstract members of State

        public override void Start()
        {
            if (OnStart != null)
                OnStart();
        }

        public override void End()
        {
            if (OnEnd != null)
                OnEnd();
        }

        public override void Update(GameTime gameTime)
        {
            if (Out != null)
            {
                if (Out.IsFinished != _oldState && OnHalf != null)
                    OnHalf();
                _oldState = Out.IsFinished;
            }

            if (InitialState != null && Out != null && !Out.IsFinished)
                Out.Update(gameTime, OutSpeed);
            else if (TargetState != null && In != null && !In.IsFinished)
                In.Update(gameTime, InSpeed);
            else
                _engine.SwitchState(TargetState);
        }

        public override void Draw(Renderer renderer, GameTime time)
        {
            if (InitialState != null && Out != null && !Out.IsFinished)
                Out.Draw(InitialState);
            else if (TargetState != null && In != null)
                In.Draw(TargetState);
        }

        public override void ProcessInput()
        {

        }

        public override void CleanUp()
        {

        }
        
        #endregion
    }
}