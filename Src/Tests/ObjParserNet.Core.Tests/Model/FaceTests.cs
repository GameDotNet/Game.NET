using System.Collections.Generic;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ObjParserNet.Core.Tests.Model
{
    [TestFixture]
    public class FaceTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanInitializePropertiesByConstructor()
        {
            Face face = new Face();

            Assert.That(face.Items, Is.Not.Null.And.Empty);
        }

        [Test]
        public void CanInitializePropertiesByConstructorWithItems()
        {
            ICollection<FaceItem> items = _fixture.Create<ICollection<FaceItem>>();
            Face face = new Face(items);

            Assert.That(face.Items, Is.Not.Null.And.EquivalentTo(items));
        }
    }
}
