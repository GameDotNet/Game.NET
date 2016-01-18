using NSubstitute;
using NUnit.Framework;
using ObjParserNet.Core;
using ObjParserNet.Parser.File;
using ObjParserNet.Parser.Parsing;
using OpenTK;
using Ploeh.AutoFixture;

namespace ObjParserNet.Parser.Tests
{
    [TestFixture]
    public class ParserTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanReturnEmptyMeshWhenFileIsEmpty()
        {
            IFileLoader loader = Substitute.For<IFileLoader>();
            loader.LoadFile(Arg.Any<string>()).Returns(new string[0]);

            IParsingService service = Substitute.For<IParsingService>();
            service.ProcessLine(Arg.Any<string>(), Arg.Any<Mesh>());
            
            Parser parser = new Parser(loader, service);
            Mesh mesh = parser.LoadMesh(_fixture.Create<string>());
            
            Assert.That(mesh.Filename, Is.Null);
            Assert.That(mesh.SubMeshes, Is.Empty);
            Assert.That(mesh.Name, Is.Null);

        }
    }
}
