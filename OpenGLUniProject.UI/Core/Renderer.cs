using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using SharpGL;

namespace OpenGLUniProject.Core
{
    public class Renderer
    {
        public Color ClearColor = Color.FromRgb(128, 64, 255);
        protected OpenGL Gl;

        private readonly GameWindow Window;

        public Renderer(OpenGL gl)
        {
            Gl = gl;
        }
        
        public void Begin()
        {
            Gl.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);
            Gl.Clear((uint)(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit));
        }

        public void End()
        {
            Gl.Flush();
        }
    }
}
