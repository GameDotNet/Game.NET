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


    }
}
