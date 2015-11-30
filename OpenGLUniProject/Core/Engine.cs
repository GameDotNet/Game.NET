using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace OpenGLUniProject.Core
{
    class Engine : IDisposable
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

        private readonly GameWindow Window;

        public string Title { get; set; } = DefaultTitle;
        
        public int Width { get; set; } = DefaultWidth;

        public int Height { get; set; } = DefaultHeight;

        public Engine(string[] args)
        {
            Window = new GameWindow(Width, Height, GraphicsMode.Default, Title);
        }

        public void Run()
        {
            Window.Run();
        }

        protected void CleanUp(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    // Clean Up managed resources
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
