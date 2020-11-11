using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CardGames.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CardDoesNotExistInCollectionException : Exception
    {
        public CardDoesNotExistInCollectionException()
        {
        }

        public CardDoesNotExistInCollectionException(string message) : base(message)
        {
        }

        public CardDoesNotExistInCollectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CardDoesNotExistInCollectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
