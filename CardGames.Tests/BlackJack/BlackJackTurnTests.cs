using CardGames.Core.BlackJack;
using CardGames.Core.PlayingCards;
using Moq;
using NUnit.Framework;
using System;

namespace CardGames.Tests.BlackJack
{
    //This test covers both the BlackJackPlayerTurn and the BlackJackDealerTurn tests, they share so much in common due to
    //the BaseBlackJackTurn abstract implementation it was easier to test them in the same rig.
    public class BlackJackTurnTests
    {
        //text output of a turn start is 

        //*********************************************
        //{Name} Turn"
        //{Name}: SFF | {to n cards} = {hand value}

        //----------------------------------------------

        //{if Busted} {Name}: Busted!
        //

        // --or--

        //{not Busted} {Name}: (H)it or (S)top? {action Hit! or Stop!}"

        private const string Name = "Tester";
        private static readonly string ExpectedHitOutcome = $"*********************************************\n{Name} Turn\n{Name}: H Q | S 9 = 19 \n{Name}: (H)it or (S)top? Hit! \n{Name}: H Q | S 9 | C K = 29 \n{Name}: Busted!\n\n";
        private static readonly string ExpectedStopOutcome = $"*********************************************\n{Name} Turn\n{Name}: H Q | S 9 = 19 \n{Name}: (H)it or (S)top? Stop! \n\n\n";

        [Test]
        public void StartTurn_BlackJackPlayerTurn_StopActionOutputCheck()
        {
            var console = new TestConsole(new ConsoleKeyInfo('S', ConsoleKey.S, false, false, false));

            var turn = new BlackJackPlayerTurn(CreateHand(), Name, () => { }, CreateDeck(), console);

            turn.StartTurn();

            Assert.AreEqual(ExpectedStopOutcome, console.Result);
        }

        [Test]
        public void StartTurn_BlackJackPlayerTurn_HitActionOutputCheck()
        {
            var console = new TestConsole(new ConsoleKeyInfo('H', ConsoleKey.H, false, false, false));

            var turn = new BlackJackPlayerTurn(CreateHand(), Name, () => { }, CreateDeck(), console);

            turn.StartTurn();

            Assert.AreEqual(ExpectedHitOutcome, console.Result);
        }

        [Test]
        public void StartTurn_BlackJackDealerTurn_StopActionOutputCheck()
        {
            var console = new TestConsole();
            var mock = new Mock<IBlackJackDealerAi>();

            mock.Setup(x => x.ShouldHit()).Returns(false);

            var turn = new BlackJackDealerTurn(CreateHand(), Name, () => { }, CreateDeck(), console, mock.Object);

            turn.StartTurn();

            Assert.AreEqual(ExpectedStopOutcome, console.Result);
        }

        [Test]
        public void StartTurn_BlackJackDealerTurn_HitActionOutputCheck()
        {
            var console = new TestConsole();
            var mock = new Mock<IBlackJackDealerAi>();

            mock.Setup(x => x.ShouldHit()).Returns(true);

            var turn = new BlackJackDealerTurn(CreateHand(), Name, () => { }, CreateDeck(), console, mock.Object);

            turn.StartTurn();

            Assert.AreEqual(ExpectedHitOutcome, console.Result);
        }

        private static PlayingCardDeck CreateDeck()
        {
            var deck = new PlayingCardDeck();

            deck.AddCardToBottom(new PlayingCard(SuitType.Club, FaceType.King));

            return deck;
        }

        private static BlackJackHand CreateHand()
        {
            var hand = new BlackJackHand();

            hand.AddCard(new PlayingCard(SuitType.Heart, FaceType.Queen));
            hand.AddCard(new PlayingCard(SuitType.Spade, FaceType.Nine));

            return hand;
        }
    }
}
