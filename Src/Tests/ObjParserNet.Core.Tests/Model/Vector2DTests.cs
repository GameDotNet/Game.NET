using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class Vector2DTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanAssingSingleValueByConstructor()
        {
            float value = _fixture.Create<float>();

            Vector2D vector = new Vector2D(value);

            Assert.That(vector, Is.Not.EqualTo(default(Vector2D)));
            Assert.That(vector.X, Is.EqualTo(value));
            Assert.That(vector.Y, Is.EqualTo(value));
        }

        [Test]
        public void CanAssignValuesByContructor()
        {
            float yValue = _fixture.Create<float>();
            float xValue = _fixture.Create<float>();

            Vector2D vector = new Vector2D(xValue, yValue);

            Assert.That(vector, Is.Not.EqualTo(default(Vector2D)));
            Assert.That(vector.X, Is.EqualTo(xValue));
            Assert.That(vector.Y, Is.EqualTo(yValue));
        }
    }
}
