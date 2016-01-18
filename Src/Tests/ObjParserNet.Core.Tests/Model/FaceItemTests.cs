using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class FaceItemTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanInitializePropertiesByConstructor()
        {
            FaceItem faceItem = new FaceItem();

            Assert.That(faceItem.Normal, Is.EqualTo(default(uint)));
            Assert.That(faceItem.Texture, Is.EqualTo(default(uint)));
            Assert.That(faceItem.Vertex, Is.EqualTo(default(uint)));
        }

        [Test]
        public void CanInitializeAllPropertiesByConstructor()
        {
            uint vertex = _fixture.Create<uint>();
            uint texture = _fixture.Create<uint>();
            uint normal = _fixture.Create<uint>();

            FaceItem faceItem = new FaceItem(vertex, texture, normal);

            Assert.That(faceItem.Normal, Is.EqualTo(normal));
            Assert.That(faceItem.Texture, Is.EqualTo(texture));
            Assert.That(faceItem.Vertex, Is.EqualTo(vertex));
        }
    }
}
