using System.Collections.Generic;
using NUnit.Framework;
using OpenTK;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class MeshTests
    {
        void setup()
        {
            _fixture.Customize<Vector3>(composer => composer
                .Without(v => v.Xy)
                .Without(v => v.Xy));
        }

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
            Vector3 minVertex = Vector3.One;
            Vector3 maxVertex = Vector3.One;
            List<SubMesh> subMeshes = _fixture.Create<List<SubMesh>>();
        
            Mesh mesh = new Mesh(filename, minVertex, maxVertex, subMeshes);

            Assert.That(mesh.Filename, Is.EqualTo(filename));
            Assert.That(mesh.MinVertex, Is.EqualTo(minVertex));
            Assert.That(mesh.MaxVertex, Is.EqualTo(maxVertex));
            Assert.That(mesh.SubMeshes, Is.Not.Null.And.EquivalentTo(subMeshes));
        }
    }
}
