using CardGames.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core
{
    public abstract class Deck<T> where T : ICard
    {
        public IList<T> Cards { private set; get; } = new List<T>();

        public abstract void AddCards();

        public void Shuffle()
        {
            //not the most efficient way to do this
            Cards = Cards.OrderBy(card => Guid.NewGuid()).ToList();
        }

        public T DrawCard()
        {
            if (Cards.Count == 0)
            {
                throw new NoAvailableCardsException("Deck has no available cards to draw.");
            }

            var card = Cards.TakeLast(1).First();

            Cards.RemoveAt(Cards.Count - 1);

            return card;
        }

        public void ClearCards()
        {
            Cards.Clear();
        }

        public void AddCardToBottom(T card)
        {
            if (Cards.Contains(card))
            {
                throw new CardAlreadyExistsInCollectionException($"The deck already contains Card:{card} and cannot be added to the bottom of deck.");
            }

            Cards.Insert(0, card);
        }
    }
}
