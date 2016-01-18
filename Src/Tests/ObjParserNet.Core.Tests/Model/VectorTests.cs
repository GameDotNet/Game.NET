using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class VectorTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanAssignValueByContructorTest()
        {
            float value = _fixture.Create<float>();

            Vector vector = new Vector(value);

            Assert.That(vector, Is.Not.Null);
            Assert.That(vector.X, Is.EqualTo(value));
        }

        [Test]
        public void AreVectorsEqual()
        {
            float value = _fixture.Create<float>();

            Vector first = new Vector(value);
            Vector second = new Vector(value);
            
            Assert.That(ReferenceEquals(first, second), Is.False);
            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        public void IsVectorCopyable()
        {
            float value = _fixture.Create<float>();

            Vector vector = new Vector(value);
            Vector copy = vector.Copy();

            Assert.That(vector, Is.Not.EqualTo(default(Vector)));
            Assert.That(ReferenceEquals(vector, copy), Is.False);
            Assert.That(vector, Is.EqualTo(copy));
        }
    }
}
