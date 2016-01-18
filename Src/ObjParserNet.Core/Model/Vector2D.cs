namespace ObjParserNet.Core
{
    public class Vector2D : Vector
    {
        public Vector2D()
        {
        }

        public Vector2D(float value) : base(value)
        {
            Y = value;
        }

        public Vector2D(float xValue, float yValue) : base(xValue)
        {
            Y = yValue;
        }

        public float Y { get; set; }
    }
}
