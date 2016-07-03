using System.Collections.Generic;
using Game.NET.Gfx;
using Game.NET.Logic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Core
{
    public class Engine
    {
        public GameTime Time { get; private set; }

        public State CurrentState { get; private set; }

        public bool IsDone { get; private set; }

        private List<State> states = new List<State>();

        private Renderer renderer = new Renderer();

        private GameWindow window;

        private float fpsTime;
        private int frames;

        public Engine()
        {
            IsDone = true;
        }

        public bool Init(string[] argv = null, string config = "Config.cfg")
        {
            IsDone = false;

            renderer.CreateBatch("default");

            return true;
        }

        public void SwitchState(State state)
        {
            if (CurrentState != null) CurrentState.End();

            CurrentState = state;

            if (CurrentState != null) CurrentState.Start();
        }

        public void ProcessInput()
        {
            if(CurrentState != null) CurrentState.ProcessInput();
        }

        public void Update(GameTime time)
        {
            time.RealTime += time.DeltaTime;
            time.Time += time.Speed * time.DeltaTime;

            if (fpsTime >= 1.0f)
            {
                time.Fps = frames / fpsTime;
                frames = 0;
                fpsTime = 0.0f;
            }
            
            if (CurrentState != null) CurrentState.Update(time);
        }

        public void Draw(GameTime time)
        {
            frames++;
            fpsTime += time.DeltaTime;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (CurrentState != null) CurrentState.Draw(renderer, time);

            renderer.Draw();
        }

        public void Exit()
        {
            IsDone = true;
        }

        public void CleanUp()
        {
            IsDone = true;
            // free data
        }
    }
}
