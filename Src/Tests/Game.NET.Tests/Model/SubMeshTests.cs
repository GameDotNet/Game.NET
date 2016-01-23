using NUnit.Framework;

namespace Game.NET.Tests.Model
{
    [TestFixture]
    public class SubMeshTests
    {
        [Test]
        public void CanInitializePropertiesByConstructor()
        {
            SubMesh subMesh = new SubMesh();

            Assert.That(subMesh.Faces, Is.Not.Null.And.Empty);
            Assert.That(subMesh.Normals, Is.Not.Null.And.Empty);
            Assert.That(subMesh.Textures, Is.Not.Null.And.Empty);
            Assert.That(subMesh.Vertices, Is.Not.Null.And.Empty);
        }
    }
}
