namespace ObjParserNet.Core.Model
{
    public class Vector3D : Vector2D
    {
        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Z { get; set; }
    }
}
