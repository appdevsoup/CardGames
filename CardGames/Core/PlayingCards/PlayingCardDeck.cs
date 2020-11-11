using System;

namespace CardGames.Core.PlayingCards
{
    public class PlayingCardDeck : Deck<PlayingCard>
    {
        public override void AddCards()
        {
            foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
            {
                foreach (FaceType face in Enum.GetValues(typeof(FaceType)))
                {
                    Cards.Add(new PlayingCard(suit, face));
                }
            }
        }
    }
}
