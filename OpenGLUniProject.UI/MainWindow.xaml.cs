using System.Windows;
using SharpGL.SceneGraph;

namespace OpenGLUniProject.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OpenGL handler
        /// </summary>
        /// <param name="sender">OpenGL control</param>
        /// <param name="args">Entry arguments</param>
        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
        }
    }
}
