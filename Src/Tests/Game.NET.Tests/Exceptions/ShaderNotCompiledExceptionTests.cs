using NUnit.Framework;

namespace Game.NET.Tests.Exceptions
{
    [TestFixture]
    public class ShaderNotCompiledExceptionTests
    {
        [Test]
        public void Ctor_AssingsMessage()
        {
            ShaderNotCompiledException ex = new ShaderNotCompiledException();

            Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Ctor_AssingsPassedMessage()
        {
            const string message = "lorem ipsum";

            ShaderNotCompiledException ex = new ShaderNotCompiledException(message);

            Assert.That(ex.Message, Is.EqualTo(message));
        }
    }
}
