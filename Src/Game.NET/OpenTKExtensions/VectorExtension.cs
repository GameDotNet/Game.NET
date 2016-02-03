using System.Numerics;

namespace Game.NET.OpenTKExtensions
{
    public static class VectorExtension
    {
        public static Vector3 ToNumericVector(this OpenTK.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        public static OpenTK.Vector3 ToOpenTKVector(this Vector3 vector)
        {
            return new OpenTK.Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}
