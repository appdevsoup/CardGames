using CardGames.Core.BlackJack;
using CardGames.Core.PlayingCards;

namespace CardGames.Tests.BlackJack
{
    public static class BlackJackHandHelper
    {
        public static BlackJackHand SimpleHand(FaceType face)
        {
            var hand = new BlackJackHand();

            hand.AddCard(new PlayingCard(SuitType.Spade, face));

            return hand;
        }

        public static BlackJackHand SimpleHand(FaceType face, FaceType face2)
        {
            var hand = SimpleHand(face);

            hand.AddCard(new PlayingCard(SuitType.Heart, face2));

            return hand;
        }

        public static BlackJackHand SimpleHand(FaceType face, FaceType face2, FaceType face3)
        {
            var hand = SimpleHand(face, face2);

            hand.AddCard(new PlayingCard(SuitType.Club, face3));

            return hand;
        }
    }
}
