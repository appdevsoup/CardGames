using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Core.BlackJack
{
    public class BlackJackGameEngine
    {
        private readonly BlackJackTable _table;

        private readonly IList<BaseBlackJackTurn> _turns = new List<BaseBlackJackTurn>();

        private readonly IConsole _console;

        public BlackJackGameEngine(IConsole console)
        {
            _console = console;
            _table = new BlackJackTable(_console, 1);
        }

        public int Turn { private set; get; }

        public void Start()
        {
            Console.Write("How Many Players (1-4)? ");

            var playerCount = WaitForPlayerCount();

            BeginGame(playerCount);
        }

        private void BeginGame(int playerCount)
        {
            InitializeTable(playerCount);

            InitializeTurns();

            _table.ReportTable();

            DoTurn();
        }

        private void DoTurn()
        {
            var turn = _turns[Turn];

            turn.StartTurn();
        }

        private void NextTurn()
        {
            Turn++;

            if (Turn >= _turns.Count)
            {
                EndGame();
            }
            else
            {
                DoTurn();
            }
        }

        private void EndGame()
        {
            _console.WriteLine("*********************************************");
            _console.WriteLine("Game Over");
            _console.WriteLine("");

            _table.ReportResults();
        }

        private void InitializeTable(int playerCount)
        {
            _table.PlayerCount = playerCount;
            _table.BeginGame();
        }

        private void InitializeTurns()
        {
            _turns.Clear();

            Turn = 0;

            foreach (var (name, hand) in _table.Players)
            {
                _turns.Add(new BlackJackPlayerTurn(hand, name, NextTurn, _table.Deck, _console));
            }

            var ai = new BlackJackDealerAi(playerHands: _table.Players.Select(x => x.Item2).ToList(), _table.Dealer);

            _turns.Add(new BlackJackDealerTurn(_table.Dealer, "Dealer", EndGame, _table.Deck, _console, ai));
        }

        private static int WaitForPlayerCount()
        {
            while (true)
            {
                var info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("1");
                    return 1;
                }

                if (info.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("2");
                    return 2;
                }

                if (info.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("3");
                    return 3;
                }

                if (info.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("4");
                    return 4;
                }
            }
        }
    }
}
