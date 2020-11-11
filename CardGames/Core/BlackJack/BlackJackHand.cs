using CardGames.Core.PlayingCards;

namespace CardGames.Core.BlackJack
{
    public class BlackJackHand : Hand<PlayingCard>
    {
        public bool IsBust
        {
            get
            {
                var v = CalculateValue();

                return (v > 21);
            }
        }

        public int CalculateValue()
        {
            var totalValue = 0;

            var aceCount = 0;

            foreach (var card in Cards)
            {
                var v = CalculateCardValue(card);

                if (v == 1)
                {
                    aceCount++;
                }
                else
                {
                    totalValue += v;
                }
            }

            //because aces can be of a value of 1 or 11, we are going to count the total aces, 
            //and use that to determine the total value of the aces given the values of the
            //remaining cards.
            if (aceCount > 0)
            {
                totalValue = CalculateAceValues(aceCount, totalValue);
            }


            return totalValue;
        }

        private static int CalculateAceValues(int totalAces, int preTotal)
        {
            var grandTotal = preTotal;

            //simple idea, if a hand has more than 1 ace, only 1 ace can be the
            //value of 11, all other aces have to be a value of 1.
            if (totalAces > 1)
            {
                grandTotal += totalAces - 1;
            }

            return ((grandTotal + 11) > 21) ? grandTotal + 1 : grandTotal + 11;
        }

        private static int CalculateCardValue(PlayingCard card)
        {
            var initialValue = (int)card.Face;

            return initialValue <= 10 ? initialValue : 10;
        }
    }
}
