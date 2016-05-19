using System;

namespace Game.NET
{
    [Serializable]
    public class GameException : Exception
    {
        public GameException()
        {
        }

        public GameException(string message) : base(message)
        {
        }

        public GameException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
