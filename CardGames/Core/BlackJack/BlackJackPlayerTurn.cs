using CardGames.Core.PlayingCards;
using System;

namespace CardGames.Core.BlackJack
{
    public class BlackJackPlayerTurn : BaseBlackJackTurn
    {
        public BlackJackPlayerTurn(BlackJackHand hand, string name, Action onCompleteAction, PlayingCardDeck deck, IConsole console) :
            base(deck, hand, name, onCompleteAction, console)
        {
        }

        public override void WaitForResponse()
        {
            while (true)
            {
                var info = OutputConsole.ReadKey(true);

                if (info.Key == ConsoleKey.H)
                {
                    OutputConsole.Write($"Hit! \n");

                    Hit();

                    DoTurn();
                    break;
                }

                if (info.Key == ConsoleKey.S)
                {
                    OutputConsole.WriteLine($"Stop! \n\n");

                    TurnComplete();
                    break;
                }
            }
        }
    }
}
