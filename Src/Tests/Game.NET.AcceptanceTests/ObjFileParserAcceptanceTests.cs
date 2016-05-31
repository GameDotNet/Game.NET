using System.IO;
using System.Linq;
using System.Reflection;
using Game.NET.Parsing;
using NUnit.Framework;

namespace Game.NET.AcceptanceTests
{
    [TestFixture]
    public class ObjFileParserAcceptanceParserTests
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                return Path.GetDirectoryName(codeBase.Substring(8));
            }
        }

        [Test]
        public void CanLoadSampleObject()
        {
            string fileName = "box.obj.txt";
            string path = $"{AssemblyDirectory}\\FakeData\\{fileName}";

            FileParser p = new FileParser();
            Mesh mesh = p.LoadMesh(path, FileType.Obj);

            Assert.That(mesh, Is.Not.Null);
            Assert.That(mesh.Filename, Is.EqualTo(fileName));

            // object
            Assert.That(mesh.SubMeshes.Count, Is.EqualTo(1));

            // vertex
            SubMesh submesh = mesh.SubMeshes.First();
            Assert.That(submesh.Vertices.Count, Is.EqualTo(12));

            // normal
            Assert.That(submesh.Normals.Count, Is.EqualTo(6));

            // face
            Assert.That(submesh.Faces.Count, Is.EqualTo(20));
        }

        [Test]
        public void CanLoadSound()
        {
            var fileName = "sound.mp3";
            var path = $"{AssemblyDirectory}\\FakeData\\{fileName}";

            var parser = new FileParser();
            var sound = parser.LoadSound(path, FileType.Obj);

            Assert.That(sound, Is.Not.Null);
            Assert.That(sound.SoundArray, Is.Not.Null);
            Assert.That(sound.FileName, Is.Not.Null);
            Assert.That(sound.FileExtension, Is.Not.Null);
            StringAssert.IsMatch(sound.FileName, "sound.mp3");
            StringAssert.IsMatch(sound.FileExtension, ".mp3");
        }
    }
}
