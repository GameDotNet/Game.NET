﻿namespace OpenGLUniProject.Core.Model
{
    public struct FaceItem
    {
        public FaceItem(uint vertex = 0, uint texture = 0, uint normal = 0)
        {
            Vertex = vertex;
            Texture = texture;
            Normal = normal;
        }

        public uint Vertex { get; set; }
        public uint Texture { get; set; }
        public uint Normal { get; set; }
    }
}