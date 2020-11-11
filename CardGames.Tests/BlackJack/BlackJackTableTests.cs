using CardGames.Core.BlackJack;
using CardGames.Core.PlayingCards;
using NUnit.Framework;
using System;
using System.Linq;

namespace CardGames.Tests.BlackJack
{
    [TestFixture]
    public class BlackJackTableTests
    {
        private const string Name = "Tester";

        [Test]
        [TestCase(0, TestName = "PlayerCount_IntOutOfRangeLower")]
        [TestCase(5, TestName = "PlayerCount_IntOutOfRangeUpper")]
        public void PlayerCount_IntOutOfRange(int playerCount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var table = new BlackJackTable(new TestConsole(), playerCount);
            });
        }

        [Test]
        public void ReportTable_StandardOutput()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"Dealer: *** | S 9\n{Name}: H Q | S 9 = 19 \n";

            SetupHand(table.Dealer);
            SetupHand(player);

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportTable();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_BothBust()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} loses.\n";

            SetupHand(table.Dealer);
            table.Dealer.AddCard(new PlayingCard(SuitType.Diamond, FaceType.King));
            SetupHand(player);
            player.AddCard(new PlayingCard(SuitType.Diamond, FaceType.King));

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_PlayerBust()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} loses.\n";

            SetupHand(table.Dealer);
            SetupHand(player);
            player.AddCard(new PlayingCard(SuitType.Diamond, FaceType.King));

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_PlayerLowScore()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} loses.\n";

            SetupHand(table.Dealer);
            table.Dealer.AddCard(new PlayingCard(SuitType.Diamond, FaceType.Two));
            SetupHand(player);

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_DealerBusts()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} wins!\n";

            SetupHand(table.Dealer);
            table.Dealer.AddCard(new PlayingCard(SuitType.Diamond, FaceType.King));
            SetupHand(player);

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_PlayerHighScore()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} wins!\n";

            SetupHand(table.Dealer);
            SetupHand(player);
            player.AddCard(new PlayingCard(SuitType.Diamond, FaceType.Two));

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        public void ReportResults_Tie()
        {
            var console = new TestConsole();
            var table = new BlackJackTable(console, 1);
            var player = new BlackJackHand();

            var expected = $"{Name} tied with dealer.\n";

            SetupHand(table.Dealer);
            SetupHand(player);

            table.Players.Add(new Tuple<string, BlackJackHand>(Name, player));

            table.ReportResults();

            Assert.AreEqual(expected, console.Result);
        }

        [Test]
        [TestCase(1, TestName = "BeginGame_InitializedPlayers_1Player")]
        [TestCase(2, TestName = "BeginGame_InitializedPlayers_2Player")]
        [TestCase(3, TestName = "BeginGame_InitializedPlayers_3Player")]
        [TestCase(4, TestName = "BeginGame_InitializedPlayers_4Player")]
        public void BeginGame_InitializedVariousPlayers(int playerCount)
        {
            var table = new BlackJackTable(new TestConsole(), playerCount);

            table.BeginGame();


            //asserts that all players exist and that all were dealt 2 cards at start
            Assert.AreEqual(playerCount, table.Players.Count);
            Assert.AreEqual(playerCount, table.Players.Count(x => x.Item2.Cards.Count == 2));
        }

        [Test]
        public void BeginGame_InitializedDealers()
        {
            var table = new BlackJackTable(new TestConsole(), 1);

            table.BeginGame();

            //asserts that dealer was dealt 2 cards at start
            Assert.AreEqual(2, table.Dealer.Cards.Count);
        }

        [Test]
        public void BeginGame_InitializedDeck()
        {
            var table = new BlackJackTable(new TestConsole(), 1);

            table.BeginGame();

            Assert.IsTrue(table.Deck.Cards.Count > 0);
        }

        private static void SetupHand(BlackJackHand hand)
        {
            hand.AddCard(new PlayingCard(SuitType.Heart, FaceType.Queen));
            hand.AddCard(new PlayingCard(SuitType.Spade, FaceType.Nine));
        }
    }
}
