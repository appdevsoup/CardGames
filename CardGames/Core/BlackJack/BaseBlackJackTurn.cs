using CardGames.Core.PlayingCards;
using System;

namespace CardGames.Core.BlackJack
{
    //the turns are a simple way to control the flow of the Hit or Stop process of BlackJack
    //which is unique to this process. It allowed for reduction of complexity by separating
    //the turn logic from the overall engine itself.

    public abstract class BaseBlackJackTurn
    {
        private readonly Action _onCompleteAction;

        private readonly PlayingCardDeck _deck;

        protected BaseBlackJackTurn(PlayingCardDeck deck, BlackJackHand hand, string name, Action onCompleteAction, IConsole console)
        {
            Name = name;
            OutputConsole = console;
            Hand = hand;

            _deck = deck;
            _onCompleteAction = onCompleteAction;
        }

        public string Name { get; }

        public BlackJackHand Hand { get; }

        public IConsole OutputConsole { get; }

        public void StartTurn()
        {
            OutputConsole.WriteLine("*********************************************");
            OutputConsole.WriteLine($"{Name} Turn");
            DoTurn();
        }

        //wait for response depends on the type of turn and therefore is the overrideable
        //component of the BlackJackTurn. One waits for user interaction, and the other 
        //uses a basic dealer AI to decide what to do.
        public abstract void WaitForResponse();

        protected void Hit()
        {
            var card = _deck.DrawCard();
            Hand.AddCard(card);
        }

        protected void DoTurn()
        {
            DisplayHand();

            if (Hand.IsBust)
            {
                OutputConsole.Write($"{Name}: Busted!\n\n");
                TurnComplete();
                return;
            }

            OutputConsole.Write($"{Name}: (H)it or (S)top? ");

            WaitForResponse();
        }

        protected void DisplayHand()
        {
            OutputConsole.Write($"{Name}: ");

            var isFirst = true;

            foreach (var card in Hand.Cards)
            {
                if (!isFirst)
                {
                    OutputConsole.Write(" | ");
                }
                else
                {
                    isFirst = false;
                }

                OutputConsole.Write($"{card}");
            }

            OutputConsole.Write($" = {Hand.CalculateValue()} \n");
        }

        protected void TurnComplete()
        {
            _onCompleteAction.Invoke();
        }
    }
}
