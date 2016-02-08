using System.Linq;
using System.Numerics;
using Game.NET.Parser.Parsing;
using NUnit.Framework;

namespace Game.NET.Parser.Tests.Parsing
{
    [TestFixture]
    public class ParsingWorkerTests
    {
        [Test]
        public void ProcessObject_ShouldAddNewSubmesh()
        {
            Mesh mesh = new Mesh();
            int baseSubmeshCount = mesh.SubMeshes.Count;
            ParsingWorker worker = new ParsingWorker();
            worker.ProcessObject(string.Empty, mesh);

            Assert.That(mesh.SubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
        }

        [Test]
        public void ProcessVertex_ShouldAddSubmeshIfCollectionIsEmpty()
        {
            Mesh mesh = new Mesh();
            ParsingWorker worker = new ParsingWorker();
            int baseSubmeshCount = mesh.SubMeshes.Count;
            worker.ProcessVertex(string.Empty, mesh);

            Assert.That(mesh.SubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
        }

        [Test]
        public void ProcessVertex_ShouldAddVector3ToTheLastSubmeshAndAssingMinVertex()
        {
            Mesh mesh = new Mesh();
            ParsingWorker worker = new ParsingWorker();
            int baseSubmeshCount = mesh.SubMeshes.Count;

            float x = 1.000000f;
            float y = 1.000000f;
            float z = 1.000000f;
            string line = $"v {x} {y} {z}";
            worker.ProcessVertex(line, mesh);

            Assert.That(mesh.SubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
            Assert.That(mesh.SubMeshes.Last().Vertices.Count, Is.EqualTo(1));

            Vector3 lastVerticle = mesh.SubMeshes.Last().Vertices.First();

            Assert.That(lastVerticle.X, Is.EqualTo(x));
            Assert.That(lastVerticle.Y, Is.EqualTo(y));
            Assert.That(lastVerticle.Z, Is.EqualTo(z));

            Assert.That(mesh.MinVertex.X, Is.EqualTo(x));
            Assert.That(mesh.MinVertex.Y, Is.EqualTo(y));
            Assert.That(mesh.MinVertex.Z, Is.EqualTo(z));

            Assert.That(mesh.MaxVertex.X, Is.EqualTo(x));
            Assert.That(mesh.MaxVertex.Y, Is.EqualTo(y));
            Assert.That(mesh.MaxVertex.Z, Is.EqualTo(z));
        }

        [Test]
        public void ProcessVertex_ShouldApplyNewValuesOfMaxAndMinVertex()
        {
            Mesh mesh = new Mesh();
            ParsingWorker worker = new ParsingWorker();

            float x = 1.000000f;
            float y = 1.000000f;
            float z = 1.000000f;
            string line = $"v {x} {y} {z}";
            worker.ProcessVertex(line, mesh);

            x = -1.000000f;
            y = -1.000000f;
            z = -1.000000f;
            line = $"v {x} {y} {z}";
            worker.ProcessVertex(line, mesh);

            Assert.That(mesh.MinVertex.X, Is.EqualTo(x));
            Assert.That(mesh.MinVertex.Y, Is.EqualTo(y));
            Assert.That(mesh.MinVertex.Z, Is.EqualTo(z));

            x = 2.000000f;
            y = 2.000000f;
            z = 2.000000f;
            line = $"v {x} {y} {z}";
            worker.ProcessVertex(line, mesh);

            Assert.That(mesh.MaxVertex.X, Is.EqualTo(x));
            Assert.That(mesh.MaxVertex.Y, Is.EqualTo(y));
            Assert.That(mesh.MaxVertex.Z, Is.EqualTo(z));
        }
    }
}
