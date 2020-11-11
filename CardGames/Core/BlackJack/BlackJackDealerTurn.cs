using CardGames.Core.PlayingCards;
using System;

namespace CardGames.Core.BlackJack
{
    public class BlackJackDealerTurn : BaseBlackJackTurn
    {
        private readonly IBlackJackDealerAi _ai;

        public BlackJackDealerTurn(BlackJackHand hand, string name, Action onCompleteAction, PlayingCardDeck deck, IConsole console, IBlackJackDealerAi ai) :
            base(deck, hand, name, onCompleteAction, console)
        {
            _ai = ai;
        }

        public override void WaitForResponse()
        {
            if (_ai.ShouldHit())
            {
                OutputConsole.Write($"Hit! \n");

                Hit();

                DoTurn();
            }
            else
            {
                OutputConsole.WriteLine($"Stop! \n\n");

                TurnComplete();
            }
        }
    }
}
