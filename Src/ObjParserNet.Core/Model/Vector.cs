using System;

namespace ObjParserNet.Core
{
    public class Vector : ICopyable<Vector>
    {
        public Vector(float value)
        {
            X = value;
        }

        public float X { get; set; }

        public Vector Copy()
        {
            return new Vector(X);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return Equals((Vector)obj);
        }

        public bool Equals(Vector vector)
        {
            if (vector == null)
                return false;
            return GetHashCode() == vector.GetHashCode();
        }
    }
}
