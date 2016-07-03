using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Gfx
{
    public class RenderBatch
    {
        private List<Renderer.DrawMeshCommand> _commands = new List<Renderer.DrawMeshCommand>();

        public void Add(Renderer.DrawMeshCommand cmd)
        {
            _commands.Add(cmd);
        }

        public void Submit()
        {
            foreach (var cmd in _commands)
            {
                cmd.material.Use();
                cmd.mesh.Use();
                
                //GL.DrawElements(cmd.mode, cmd.count, cmd.type, cmd.mesh.indicies);
            }

            _commands.Clear();
        }
    }
}
