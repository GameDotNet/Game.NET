using System.Collections.Generic;
using Game.NET.Resources;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Gfx
{
    public class Renderer
    {
        private Dictionary<string, RenderBatch> batches = new Dictionary<string, RenderBatch>();
        private RenderTarget _target;

        public class DrawMeshCommand
        {
            public BaseSubMesh mesh;
            public Material material;
        }

        public void SetRenderTarget(RenderTarget target)
        {
            _target = target;
        }

        public void CreateBatch(string name)
        {
            batches.Add(name, new RenderBatch());
        }

        public void DrawMesh(DrawMeshCommand cmd, string batch)
        {
            batches[batch].Add(cmd);
        }

        public void Draw()
        {
            if (_target == null)
                return;

            _target.Use();
            _target.Clear();

            foreach (var batch in batches.Values)
            {
                batch.Submit();
            }

            _target.Swap();
        }
    }
}
