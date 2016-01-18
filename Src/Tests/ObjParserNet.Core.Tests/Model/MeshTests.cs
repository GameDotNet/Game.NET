using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class MeshTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanInitializePropertiesByConstructor()
        {
            Mesh mesh = new Mesh();

            Assert.That(mesh.SubMeshes, Is.Not.Null.And.Empty);
        }

        [Test]
        public void CanInitializeAllPropertiesByConstructor()
        {
            string filename = _fixture.Create<string>();
            Vector3D minVertex = _fixture.Create<Vector3D>();
            Vector3D maxVertex = _fixture.Create<Vector3D>();

            List<SubMesh> subMeshes = new List<SubMesh> { new SubMesh() };

            Mesh mesh = new Mesh(filename, minVertex, maxVertex, subMeshes);

            Assert.That(mesh.Filename, Is.EqualTo(filename));
            Assert.That(mesh.MinVertex, Is.EqualTo(minVertex));
            Assert.That(mesh.MaxVertex, Is.EqualTo(maxVertex));
            Assert.That(mesh.SubMeshes, Is.Not.Null.And.Count.EqualTo(subMeshes.Count));
        }
    }
}
