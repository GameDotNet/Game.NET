using System;
using NUnit.Framework;

namespace Game.NET.Tests.Exceptions
{
    [TestFixture]
    public class ShaderCompilationErrorExceptionTests
    {
        [Test]
        public void Ctor_AssingsMessage()
        {
            ShaderCompilationErrorException ex = new ShaderCompilationErrorException();

            Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Ctor_AssingsPassedMessage()
        {
            const string message = "lorem ipsum";

            ShaderCompilationErrorException ex = new ShaderCompilationErrorException(message);

            Assert.That(ex.Message, Is.EqualTo(message));
        }

        [Test]
        public void Ctor_AssingsPassedException()
        {
            Exception passedEx = new Exception();

            ShaderCompilationErrorException ex = new ShaderCompilationErrorException(passedEx);

            Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
        }
    }
}
