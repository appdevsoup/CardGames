using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CardGames.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class NoAvailableCardsException : Exception
    {
        public NoAvailableCardsException()
        {
        }

        public NoAvailableCardsException(string message) : base(message)
        {
        }

        public NoAvailableCardsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NoAvailableCardsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
