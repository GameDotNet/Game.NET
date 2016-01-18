using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    class Vector3DTests
    {
        private Fixture _fixture = new Fixture();

        public void CanAssignSingleValueByContructor()
        {
            float value = _fixture.Create<float>();

            Vector3D vector = new Vector3D(value);

            Assert.That(vector, Is.Not.EqualTo(default(Vector3D)));
            Assert.That(vector.X, Is.EqualTo(value));
            Assert.That(vector.Y, Is.EqualTo(value));
            Assert.That(vector.Z, Is.EqualTo(value));
        }


        [Test]
        public void CanAssignValuesByContructor()
        {
            float yValue = _fixture.Create<float>();
            float xValue = _fixture.Create<float>();
            float zValue = _fixture.Create<float>();

            Vector3D vector = new Vector3D(xValue, yValue, zValue);

            Assert.That(vector, Is.Not.EqualTo(default(Vector3D)));
            Assert.That(vector.X, Is.EqualTo(xValue));
            Assert.That(vector.Y, Is.EqualTo(yValue));
            Assert.That(vector.Z, Is.EqualTo(zValue));
        }
    }
}
