using System.Collections.Generic;
using NUnit.Framework;
using OpenTK;
using Ploeh.AutoFixture;

namespace Game.NET.Tests.Model
{
    [TestFixture]
    public class MeshTests
    {
        [SetUp]
        public void Setup()
        {
            _fixture.OmitVector3Properties();
        }

        private readonly Fixture _fixture = new Fixture();

        [TestCase(null)]
        [TestCase("sample.obj")]
        public void CanInitializePropertiesByConstructor(string fileName)
        {
            Mesh mesh = new Mesh(fileName);

            Assert.That(mesh.Filename, Is.EqualTo(fileName));
            Assert.That(mesh.ObjSubMeshes, Is.Not.Null.And.Empty);
        }

        [Test]
        public void CanInitializeAllPropertiesByConstructor()
        {
            string filename = _fixture.Create<string>();
            List<ObjSubMesh> subMeshes = _fixture.Create<List<ObjSubMesh>>();
        
            Mesh mesh = new Mesh(filename, subMeshes);

            Assert.That(mesh.Filename, Is.EqualTo(filename));
            Assert.That(mesh.ObjSubMeshes, Is.Not.Null.And.EquivalentTo(subMeshes));
        }
    }
}
