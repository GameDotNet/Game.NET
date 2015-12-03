using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;

namespace OpenGLUniProject.Core
{
    public class Engine : IDisposable
    {
        public static readonly int DefaultWidth = 800;
        public static readonly int DefaultHeight = 600;
        public static readonly string DefaultTitle = "OpenGL Project";

        public class TimeData
        {
            public float dt;
            public float time;
            public float fps;
            public float frameTime;
            public float realTime;
            public float speed;
            public float timeStep;
            public float maxFrameTime;
        }

        private bool IsDisposed { get; set; }
        private bool IsDone { get; set; }

        private readonly TimeData currentTime = new TimeData();

        private readonly GameWindow Window;
        private readonly Renderer renderer;
        private readonly GraphicsContext context;

        public Engine(string[] args)
        {
            Window = new GameWindow(DefaultWidth, DefaultHeight, GraphicsMode.Default, DefaultTitle);
            Window.Visible = true;

            renderer = new Renderer(Window);
            Window.Closing += OnClosing;
        }
        
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            IsDone = true;
        }

        public void Run()
        {
            var lastTicks = System.Diagnostics.Stopwatch.GetTimestamp() / 1000.0f;
            var deltaTime = 0.0f;
            var accumulator = 0.0f;
            var fpsTime = 0.0f;
            var frames = 0.0f;
            var time = 0.0f;

            currentTime.timeStep = 1.0f / 60.0f;
            currentTime.speed = 1.0f;
            
            while (!IsDone)
            {
                Window.ProcessEvents();

				if(!Window.Exists || Window.IsExiting)
					break;

                deltaTime = ((System.Diagnostics.Stopwatch.GetTimestamp()) / 1000.0f) - lastTicks;
                lastTicks += deltaTime;
                deltaTime = (deltaTime > 0 ? deltaTime : 0);

                accumulator += deltaTime;
                accumulator = accumulator < 0
                    ? 0.0f
                    : (accumulator < currentTime.maxFrameTime ? currentTime.maxFrameTime : accumulator);

                while (accumulator > currentTime.timeStep)
                {
                    currentTime.dt = currentTime.timeStep;
                    currentTime.frameTime = deltaTime;
                    currentTime.realTime = time;
                    currentTime.time += deltaTime;

                    Update(currentTime);

                    accumulator -= currentTime.timeStep;
                    time += currentTime.timeStep;
                }

                frames++;
                fpsTime += deltaTime;

                if (fpsTime >= 1.0f)
                {
                    currentTime.fps = frames / fpsTime;
                    frames = 0;
                    fpsTime = 0.0f;
                }

                Draw(currentTime);
            }
        }

        public void Update(TimeData time)
        {

        }

        public void Draw(TimeData time)
        {
            renderer.Begin();
            {

            }
            renderer.End();
        }

        protected void CleanUp(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    Window.Dispose();
                }

                // Clean up unmanaged resources

            }

            IsDisposed = true;
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        ~Engine()
        {
            CleanUp(false);
        }
    }
}
