using NSubstitute;
using NUnit.Framework;
using Game.NET;
using Game.NET.Parser.File;
using Game.NET.Parser.Parsing;
using Ploeh.AutoFixture;

namespace Game.NET.Parser.Tests
{
    [TestFixture]
    public class ObjFileParserTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanReturnEmptyMeshWhenFileIsEmpty()
        {
            IFileLoader loader = Substitute.For<IFileLoader>();
            loader.LoadFile(Arg.Any<string>()).Returns(new string[0]);

            IParsingService service = Substitute.For<IParsingService>();
            service.ProcessLine(Arg.Any<string>(), Arg.Any<Mesh>());
            
            ObjFileParser objFileParser = new ObjFileParser(loader, service);
            string fileName = _fixture.Create<string>();
            Mesh mesh = objFileParser.LoadMesh(fileName);
            
            Assert.That(mesh.Filename, Is.EqualTo(fileName));
            Assert.That(mesh.SubMeshes, Is.Empty);
            Assert.That(mesh.Name, Is.Null);

        }
    }
}
