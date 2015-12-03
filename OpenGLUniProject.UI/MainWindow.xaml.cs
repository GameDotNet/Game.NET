using System.Windows;
using System.Windows.Interop;
using SharpGL;
using SharpGL.SceneGraph;
using OpenGLUniProject.Core;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLUniProject.UI
{
    public partial class MainWindow : Window
    {
        protected Engine engine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            /*engine = new Engine (
                new WindowInteropHelper(this).Handle,
                Win32.wglGetCurrentContext(), 
                function => Win32.wglGetProcAddress(function), 
                () => new ContextHandle(Win32.wglGetCurrentContext())
            );*/
        }

        /// <summary>
        /// OpenGL handler
        /// </summary>
        /// <param name="sender">OpenGL control</param>
        /// <param name="args">Entry arguments</param>
        private void OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            GlControl.OpenGL.ClearColor(1.0f, 0.5f, 0.25f, 1.0f);
            GlControl.OpenGL.Clear((uint)(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit));
            
            GlControl.OpenGL.Flush();
        }
    }
}
