using System.Linq;
using System.Numerics;
using Game.NET.Parsing.Obj;
using NUnit.Framework;

namespace Game.NET.Tests.Parsing.Obj
{
    [TestFixture]
    public class ObjParsingWorkerTests
    {
        [Test]
        public void ProcessObject_ShouldAddNewSubmesh()
        {
            Mesh mesh = new Mesh();
            int baseSubmeshCount = mesh.ObjSubMeshes.Count;
            ObjParsingWorker worker = new ObjParsingWorker();
            worker.ProcessObject(string.Empty, mesh);

            Assert.That(mesh.ObjSubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
        }

        [Test]
        public void ProcessVertex_ShouldAddSubmeshIfCollectionIsEmpty()
        {
            Mesh mesh = new Mesh();
            ObjParsingWorker worker = new ObjParsingWorker();
            int baseSubmeshCount = mesh.ObjSubMeshes.Count;
            worker.ProcessVertex(string.Empty, mesh);

            Assert.That(mesh.ObjSubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
        }

        [Test]
        public void ProcessVertex_ShouldAddVector3ToTheLastSubmeshAndAssingMinVertex()
        {
            Mesh mesh = new Mesh();
            ObjParsingWorker worker = new ObjParsingWorker();
            int baseSubmeshCount = mesh.ObjSubMeshes.Count;

            float x = 1.000000f;
            float y = 1.000000f;
            float z = 1.000000f;
            string line = $"v {x} {y} {z}";
            worker.ProcessVertex(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Count, Is.EqualTo(baseSubmeshCount + 1));
            Assert.That(mesh.ObjSubMeshes.Last().Vertices.Count, Is.EqualTo(1));

            Vector3 lastVerticle = mesh.ObjSubMeshes.Last().Vertices.First();

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
            ObjParsingWorker worker = new ObjParsingWorker();

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

        [Test]
        public void ProcessTextCoord_ThrowsWhenSubmeshCollecionIsEmpty()
        {
            Mesh mesh = new Mesh();
            ObjParsingWorker worker = new ObjParsingWorker();

            Assert.That(() => worker.ProcessTextCoord(string.Empty, mesh), Throws.InvalidOperationException);
        }

        [TestCase("n .")]
        [TestCase("n . . .")]
        public void ProcessTextCoord_ShouldReturnWhereThereIsInvalidNumberOfTokens(string line)
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();
            worker.ProcessTextCoord(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Textures, Is.Empty);
        }

        [Test]
        public void ProcessTextCoord_ShouldAddTextureToTheLastSubmesh()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            mesh.ObjSubMeshes.Add(new ObjSubMesh());

            float x = 1.000000f;
            float y = 1.000000f;
            string line = $"t {x} {y}";
            ObjParsingWorker worker = new ObjParsingWorker();
            worker.ProcessTextCoord(line, mesh);

            Vector2 lastTexture = mesh.ObjSubMeshes.Last().Textures.First();
            Assert.That(lastTexture.X, Is.EqualTo(x));
            Assert.That(lastTexture.Y, Is.EqualTo(y));
        }

        [Test]
        public void ProcessNormal_ThrowsWhenSubmeshCollecionIsEmpty()
        {
            Mesh mesh = new Mesh();
            ObjParsingWorker worker = new ObjParsingWorker();

            Assert.That(() => worker.ProcessNormal(string.Empty, mesh), Throws.InvalidOperationException);
        }

        [TestCase("n . .")]
        [TestCase("n . . . .")]
        public void ProcessNormal_ShouldReturnWhereThereIsInvalidNumberOfTokens(string line)
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();
            worker.ProcessNormal(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Textures, Is.Empty);
        }

        [Test]
        public void ProcessNormal_ShouldAddTextureToTheLastSubmesh()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            mesh.ObjSubMeshes.Add(new ObjSubMesh());

            float x = 1.000000f;
            float y = 1.000000f;
            float z = 1.000000f;
            string line = $"v {x} {y} {z}";
            ObjParsingWorker worker = new ObjParsingWorker();
            worker.ProcessNormal(line, mesh);

            Vector3 lastTexture = mesh.ObjSubMeshes.Last().Normals.First();
            Assert.That(lastTexture.X, Is.EqualTo(x));
            Assert.That(lastTexture.Y, Is.EqualTo(y));
        }

        [Test]
        public void ProcessFace_ThrowsWhenSubmeshCollecionIsEmpty()
        {
            Mesh mesh = new Mesh();
            ObjParsingWorker worker = new ObjParsingWorker();

            Assert.That(() => worker.ProcessFace(string.Empty, mesh), Throws.InvalidOperationException);
        }

        [Test]
        public void ProcessFace_ShouldAddFaceWithOneFaceItemWithVertex()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            uint value = 3;
            string line = $"f {value}";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(value));
        }

        [Test]
        public void ProcessFace_ShouldAddFaceItemWithoutVertex()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            string line = "f ";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(default(uint)));
        }

        [Test]
        public void ProcessFace_ShouldAddFaceWithOneFaceItemWithVertexAndTexture()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            uint x = 3;
            uint y = 4;
            string line = $"f {x}/{y}";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(x));
            Assert.That(faceItem.Texture, Is.EqualTo(y));
        }

        [Test]
        public void ProcessFace_ShouldAddFaceItemWithoutVertexValueAndTexture()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            string line = "f /";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(default(uint)));
            Assert.That(faceItem.Texture, Is.EqualTo(default(uint)));
        }

        [Test]
        public void ProcessFace_ShouldAddFaceWithOneFaceItemWithVertexTextureAndNormal()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            uint x = 3;
            uint y = 4;
            uint z = 5;
            string line = $"f {x}/{y}/{z}";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(x));
            Assert.That(faceItem.Texture, Is.EqualTo(y));
            Assert.That(faceItem.Normal, Is.EqualTo(z));
        }

        [Test]
        public void ProcessFace_ShouldAddFaceItemWithoutVertexTextureAndNormal()
        {
            Mesh mesh = new Mesh();
            mesh.ObjSubMeshes.Add(new ObjSubMesh());
            ObjParsingWorker worker = new ObjParsingWorker();

            string line = "f //";
            worker.ProcessFace(line, mesh);

            Assert.That(mesh.ObjSubMeshes.Last().Faces.First().Items.Count, Is.EqualTo(1));
            FaceItem faceItem = mesh.ObjSubMeshes.Last().Faces.First().Items.First();
            Assert.That(faceItem.Vertex, Is.EqualTo(default(uint)));
            Assert.That(faceItem.Texture, Is.EqualTo(default(uint)));
            Assert.That(faceItem.Normal, Is.EqualTo(default(uint)));
        }
    }
}
