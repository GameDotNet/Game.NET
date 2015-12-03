using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OpenGLUniProject.Core.Model;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenGLUniProject.Core
{
    public class Engine : IDisposable
    {
        public static readonly int DefaultWidth = 800;
        public static readonly int DefaultHeight = 600;
        public static readonly string DefaultTitle = "OpenGL Project";

        public class TimeData
        {
            public float Dt;
            public float Time;
            public float Fps;
            public float FrameTime;
            public float RealTime;
            public float Speed;
            public float TimeStep;
            public float MaxFrameTime;
        }

        private bool IsDisposed { get; set; }
        private bool IsDone { get; set; }

        private readonly TimeData _currentTime = new TimeData();

        private readonly GameWindow _window;
        private readonly Renderer _renderer;

        public Engine(string[] args)
        {
            _window = new GameWindow(DefaultWidth, DefaultHeight, GraphicsMode.Default, DefaultTitle);
            _window.Visible = true;
            _window.Closing += OnClosing;
            _window.KeyUp += WindowOnKeyUp;
            
            _renderer = new Renderer(_window);
        }

        public void Run()
        {
            var lastTicks = System.Diagnostics.Stopwatch.GetTimestamp() / 1000.0f;
            var deltaTime = 0.0f;
            var accumulator = 0.0f;
            var fpsTime = 0.0f;
            var frames = 0.0f;
            var time = 0.0f;

            _currentTime.TimeStep = 1.0f / 60.0f;
            _currentTime.Speed = 1.0f;

            while (!IsDone)
            {
                _window.ProcessEvents();

                if (!_window.Exists || _window.IsExiting)
                    break;

                deltaTime = ((System.Diagnostics.Stopwatch.GetTimestamp()) / 1000.0f) - lastTicks;
                lastTicks += deltaTime;
                deltaTime = (deltaTime > 0 ? deltaTime : 0);

                accumulator += deltaTime;
                accumulator = accumulator < 0
                    ? 0.0f
                    : (accumulator < _currentTime.MaxFrameTime ? _currentTime.MaxFrameTime : accumulator);

                while (accumulator > _currentTime.TimeStep)
                {
                    _currentTime.Dt = _currentTime.TimeStep;
                    _currentTime.FrameTime = deltaTime;
                    _currentTime.RealTime = time;
                    _currentTime.Time += deltaTime;

                    Update(_currentTime);

                    accumulator -= _currentTime.TimeStep;
                    time += _currentTime.TimeStep;
                }

                frames++;
                fpsTime += deltaTime;

                if (fpsTime >= 1.0f)
                {
                    _currentTime.Fps = frames / fpsTime;
                    frames = 0;
                    fpsTime = 0.0f;
                }

                Draw(_currentTime);
            }
        }

        public void Update(TimeData time)
        {

        }

        public void Draw(TimeData time)
        {
            _renderer.Begin();
            {

            }
            _renderer.End();
        }

        protected void CleanUp(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    _window.Dispose();
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

        private void WindowOnKeyUp(object sender, KeyboardKeyEventArgs keyboardKeyEventArgs)
        {
            switch (keyboardKeyEventArgs.Key)
            {
                case Key.O:
                    LoadFile();
                    break;
                default:
                    return;
            }
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            IsDone = true;
        }

        private void LoadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                Title = "Wybierz plik",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                DefaultExt = "obj",
                Filter = "Object files (*.obj) | *.obj"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = dialog.FileName;

                    MeshParser parser = new MeshParser();
                    Mesh mesh = parser.Parse(filePath);
                    if (mesh != null)
                    {
                        ResourceManager.AddOrUpdate("mesh", mesh);
                    }
                }
                catch (IOException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    throw;
                }
            }
        }
    }
}
