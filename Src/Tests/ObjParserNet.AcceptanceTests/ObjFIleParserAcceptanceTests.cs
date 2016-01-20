using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ObjParserNet.Core;

namespace ObjParserNet.AcceptanceTests
{
    [TestFixture]
    public class ObjFileParserAcceptanceParserTests
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        [Test]
        public void CanLoadSampleObject()
        {
            string fileName = "box.obj";
            string path = $"{AssemblyDirectory}\\FakeData\\{fileName}";

            Parser.ObjFileParser p = new Parser.ObjFileParser();
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
