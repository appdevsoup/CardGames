using CardGames.Exceptions;
using System.Collections.Generic;

namespace CardGames.Core
{
    public class Hand<T> where T : ICard
    {
        public IList<T> Cards { get; } = new List<T>();

        public void AddCard(T card)
        {
            if (Cards.Contains(card))
            {
                throw new CardAlreadyExistsInCollectionException($"Hand attempted to add Card:{card} which already was in hand.");
            }

            Cards.Add(card);
        }

        public void RemoveCard(T card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
            }
            else
            {
                throw new CardDoesNotExistInCollectionException($"Hand attempted to remove Card:{card} which did not exist in hand.");
            }
        }
    }
}
