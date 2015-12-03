using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenGLUniProject.Core
{
    public class Renderer
    {
        public Color4 ClearColor = Color4.DarkSlateBlue;

        private readonly GameWindow Window;

        public Renderer(GameWindow window = null)
        {
            if (window == null)
                return;

            Window = window;
            Window.Resize += Resize;

            Init();
        }

        private void Init()
        {
            GL.ClearDepth(1);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.Enable(EnableCap.Blend);

            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.ShadeModel(ShadingModel.Smooth);
            GL.Disable(EnableCap.Lighting);

            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
        }

        private void Resize(object sender, EventArgs e)
        {
            GL.Viewport(Window.ClientRectangle);
        }
        
        public void Begin()
        {
            GL.ClearColor(ClearColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void End()
        {
            GraphicsContext.CurrentContext.SwapBuffers();
        }

        public void DrawMesh(Mesh mesh, Color color, PrimitiveType mode = PrimitiveType.Triangles)/*,
                             Gfx.Material.SubMaterial material = null)*/
        {
            float[] color_buff = new float[4];
            GL.GetFloat(GetPName.CurrentColor, color_buff);
            
            GL.Color4(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);

            bool tex_enabled = GL.IsEnabled(EnableCap.Texture2D);
            if (!tex_enabled)
                GL.Enable(EnableCap.Texture2D);

            foreach (var subMesh in mesh.subMeshes)
            {
                foreach (var face in subMesh.faces)
                {
                    var i = 0;
                    if (face.material != null && face.material.diffTex != null || material != null)
                    {
                        if (material != null && material.diffTex != null)
                            GL.BindTexture(TextureTarget.Texture2D, material.diffTex.Id);
                        else
                            GL.BindTexture(TextureTarget.Texture2D, face.material.diffTex.Id);
                    }
                    GL.Begin(mode);
                    foreach (var item in face.items)
                    {
                        if (item.normal != 0 && item.normal - 1 < subMesh.normals.Count)
                        {
                            var n = subMesh.normals[(int)item.normal - 1];
                            GL.Normal3(n.X, n.Y, n.Z);
                        }
                        if (item.texture != 0 && item.texture - 1 < subMesh.textures.Count)
                        {
                            var t = subMesh.textures[(int)item.texture - 1];
                            GL.TexCoord2(t.X, t.Y);
                        }
                        if (item.vertex != 0 && item.vertex - 1 < subMesh.vertices.Count)
                        {
                            var v = subMesh.vertices[(int)item.vertex - 1];
                            GL.Vertex3(v.X, v.Y, v.Z);
                        }
                        i++;
                    }
                    GL.End();
                }
            }
            GL.Color4(color_buff);

            if (!tex_enabled)
                GL.Disable(EnableCap.Texture2D);
        }

        public void TempDraw()
        {
            GL.PushMatrix();
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
            }
            GL.PopMatrix();
        }
    }
}
