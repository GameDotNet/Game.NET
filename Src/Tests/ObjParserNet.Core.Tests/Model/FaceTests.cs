using NUnit.Framework;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class FaceTests
    {
        [Test]
        public void CanInitializePropertiesByConstructor()
        {
            Face face = new Face();

            Assert.That(face.Items, Is.Not.Null.And.Empty);
        }
    }
}
