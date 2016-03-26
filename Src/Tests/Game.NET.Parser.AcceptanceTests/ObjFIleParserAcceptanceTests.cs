using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Game.NET;

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

            Parser.FileParser p = new Parser.FileParser(new Parser.File.FileLoader(), new Parser.Parsing.ObjParsingService());
            Mesh mesh = p.LoadMesh(path);

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
    }
}
