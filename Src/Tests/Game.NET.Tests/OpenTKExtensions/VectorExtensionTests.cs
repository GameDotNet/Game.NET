using System.Numerics;
using Game.NET.OpenTKExtensions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Game.NET.Tests.OpenTKExtensions
{
    [TestFixture]
    public class VectorExtensionTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanConvertOpenTKVectorToNumericVector()
        {
            float x = _fixture.Create<float>();
            float y = _fixture.Create<float>();
            float z = _fixture.Create<float>();

            OpenTK.Vector3 openTKVector = new OpenTK.Vector3(x, y, z);
            Vector3 vector = openTKVector.ToNumericVector();

            Assert.That(vector, Is.Not.Null);
            Assert.That(vector.X, Is.EqualTo(openTKVector.X));
            Assert.That(vector.Y, Is.EqualTo(openTKVector.Y));
            Assert.That(vector.Z, Is.EqualTo(openTKVector.Z));
        }

        [Test]
        public void CanConvertNumericVectorToNumericVector()
        {
            float x = _fixture.Create<float>();
            float y = _fixture.Create<float>();
            float z = _fixture.Create<float>();

            Vector3 vector = new Vector3(x, y, z);
            OpenTK.Vector3 openTKVector = vector.ToOpenTKVector();

            Assert.That(openTKVector, Is.Not.Null);
            Assert.That(openTKVector.X, Is.EqualTo(vector.X));
            Assert.That(openTKVector.Y, Is.EqualTo(vector.Y));
            Assert.That(openTKVector.Z, Is.EqualTo(vector.Z));
        }

    }
}
