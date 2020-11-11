using CardGames.Extensions;

namespace CardGames.Core.PlayingCards
{
    public class PlayingCard : ICard
    {
        public PlayingCard(SuitType suit, FaceType face)
        {
            Face = face;
            Suit = suit;
        }

        public FaceType Face { get; }
        public SuitType Suit { get; }

        public override string ToString()
        {
            return $"{Suit.GetDescription()}{Face.GetDescription()}";
        }
    }
}
