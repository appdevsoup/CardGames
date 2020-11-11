using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.BlackJack
{
    public class BlackJackDealerAi : IBlackJackDealerAi
    {
        private readonly IEnumerable<BlackJackHand> _playerHands;
        private readonly BlackJackHand _dealerHand;

        public BlackJackDealerAi(IEnumerable<BlackJackHand> playerHands, BlackJackHand dealerHand)
        {
            _playerHands = playerHands;

            _dealerHand = dealerHand;
        }

        public bool ShouldHit()
        {
            //in this first iteration, the ai logic is simple. If anyone is beating the
            //dealer in blackjack, the dealer will continue to risk and hit, regardless
            //of table odds and how many players the dealer is beating, So if a person
            //is sitting at 21 and the 3 other players are below 15 and the dealer is
            //18, this ai, will hit to tie the top player. The dealer also considers
            //ties a favorable outcome.
            //
            //In some rules the dealer always stays at 17 or greater... obviously this
            //could have various opportunities for improvement.

            if (_dealerHand.IsBust)
            {
                return false;
            }

            var playerValues = _playerHands.Where(c => !c.IsBust).Select(c => 21 - c.CalculateValue()).ToList();

            var currentValue = 21 - _dealerHand.CalculateValue();

            var isPlayersWinning = playerValues.Any(c => c < currentValue);

            return isPlayersWinning;
        }
    }
}
