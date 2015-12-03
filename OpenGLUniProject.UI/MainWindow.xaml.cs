using System.Resources;
using System.Windows;
using System.Windows.Interop;
using OpenGLUniProject.Core;
using SharpGL;
using SharpGL.SceneGraph;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGLUniProject.UI
{
    public partial class MainWindow : Window
    {
        protected Renderer renderer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            renderer = new Renderer(GlControl.OpenGL);
        }

        /// <summary>
        /// OpenGL handler
        /// </summary>
        /// <param name="sender">OpenGL control</param>
        /// <param name="args">Entry arguments</param>
        private void OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            renderer.Begin();
            {
                
            }
            renderer.End();
        }
    }
}
