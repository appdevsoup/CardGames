using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CardGames.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CardAlreadyExistsInCollectionException : Exception
    {
        public CardAlreadyExistsInCollectionException()
        {
        }

        public CardAlreadyExistsInCollectionException(string message) : base(message)
        {
        }

        public CardAlreadyExistsInCollectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CardAlreadyExistsInCollectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
