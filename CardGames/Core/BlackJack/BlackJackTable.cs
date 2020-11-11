using CardGames.Core.PlayingCards;
using System;
using System.Collections.Generic;

namespace CardGames.Core.BlackJack
{
    public class BlackJackTable
    {
        private readonly IConsole _console;
        private int _playerCount = 1;

        public BlackJackTable(IConsole console, int playerCount)
        {
            PlayerCount = playerCount;

            _console = console;
        }

        public PlayingCardDeck Deck { get; } = new PlayingCardDeck();

        public int PlayerCount
        {
            get => _playerCount;
            set
            {
                if ((value <= 0) || (value > 4))
                {
                    throw new ArgumentException("Player Count is out of range. Acceptable players is 1 to 4");
                }

                _playerCount = value;
            }
        }

        public IList<Tuple<string, BlackJackHand>> Players { get; } = new List<Tuple<string, BlackJackHand>>();

        public BlackJackHand Dealer { get; private set; } = new BlackJackHand();

        public void BeginGame()
        {
            InitializePlayersAndDealer();
            InitializeDeck();
            InitializeRound();
        }

        public void ReportTable()
        {
            DisplayHand(Dealer, "Dealer", true);

            foreach (var (name, hand) in Players)
            {
                DisplayHand(hand, name, false);
            }
        }

        public void ReportResults()
        {
            foreach (var (name, hand) in Players)
            {
                if ((Dealer.IsBust && hand.IsBust)
                    || (!Dealer.IsBust && hand.IsBust)
                    || (Dealer.CalculateValue() > hand.CalculateValue() && !Dealer.IsBust && !hand.IsBust))
                {
                    _console.WriteLine($"{name} loses.");
                }
                else if ((Dealer.IsBust & !hand.IsBust)
                         || (Dealer.CalculateValue() < hand.CalculateValue() && !Dealer.IsBust && !hand.IsBust))
                {
                    _console.WriteLine($"{name} wins!");
                }
                else if (Dealer.CalculateValue() == hand.CalculateValue())
                {
                    _console.WriteLine($"{name} tied with dealer.");
                }
            }
        }

        private void DisplayHand(BlackJackHand hand, string name, bool hideFirstCard)
        {
            _console.Write($"{name}: ");

            var isFirst = true;

            foreach (var card in hand.Cards)
            {
                if (!isFirst)
                {
                    _console.Write(" | ");
                    _console.Write($"{card}");
                }
                else
                {
                    isFirst = false;

                    _console.Write(hideFirstCard ? "***" : $"{card}");
                }
            }

            _console.Write(!hideFirstCard ? $" = {hand.CalculateValue()} \n" : "\n");
        }

        private void InitializePlayersAndDealer()
        {
            Players.Clear();

            for (var i = 1; i <= PlayerCount; i++)
            {
                Players.Add(new Tuple<string, BlackJackHand>($"Player {i}", new BlackJackHand()));
            }

            Dealer = new BlackJackHand();
        }

        private void InitializeDeck()
        {
            Deck.ClearCards();
            Deck.AddCards();
            Deck.Shuffle();
        }

        private void InitializeRound()
        {
            foreach (var player in Players)
            {
                DealHand(player.Item2);
            }


            DealHand(Dealer);
        }

        private void DealHand(BlackJackHand hand)
        {
            var firstCard = Deck.DrawCard();
            var secondCard = Deck.DrawCard();

            hand.AddCard(firstCard);
            hand.AddCard(secondCard);
        }
    }
}
