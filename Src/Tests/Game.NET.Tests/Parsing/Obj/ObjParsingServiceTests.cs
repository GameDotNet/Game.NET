using System;
using System.Collections.Generic;
using Game.NET.Parsing.Obj;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Game.NET.Tests.Parsing.Obj
{
    [TestFixture]
    public class ObjParsingServiceTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly ICollection<string> _processIds = new List<string>
        {
            "o", "v", "vt", "vn", "f", "mtllib", "usemtl", "s"
        };

        [Test]
        public void CanInitializeProcessDictionary()
        {
            ObjParsingService service = new ObjParsingService();

            foreach (KeyValuePair<string, Action<string, Mesh>> pair in service.ProcessDictionary)
            {
                Assert.That(_processIds.Contains(pair.Key), Is.True);
                Assert.That(pair.Value, Is.Not.Null);
            }
        }

        [TestCase("")]
        [TestCase("#")]
        public void ReturnWhenLineIsEmpty(string line)
        {
            Mesh mesh = new Mesh();

            ObjParsingService service = new ObjParsingService();
            service.ProcessLine(line, mesh);

            Mesh emptyMesh = new Mesh();
            Assert.That(mesh.MinVertex, Is.EqualTo(emptyMesh.MinVertex));
            Assert.That(mesh.MaxVertex, Is.EqualTo(emptyMesh.MaxVertex));
            Assert.That(mesh.Filename, Is.Null);
            Assert.That(mesh.SubMeshes, Is.Empty);
        }

        [Test]
        public void ThrowsWhenProcessIdIsNotDefined()
        {
            string unknownProcessId = _fixture.Create<string>();
            Mesh mesh = new Mesh();

            ObjParsingService service = new ObjParsingService();

            Assert.That(() => service.ProcessLine(unknownProcessId, mesh), Throws.InvalidOperationException);
        }
    }
}
