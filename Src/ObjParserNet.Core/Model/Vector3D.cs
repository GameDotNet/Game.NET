namespace ObjParserNet.Core
{
    public class Vector3D : Vector2D
    {
        public Vector3D(float value) : base(value)
        {
            Z = value;
        }

        public Vector3D(float xValue, float yValue, float zValue) : base(xValue, yValue)
        {
            Z = zValue;
        }

        public float Z { get; set; }
    }
}
