using CardGames.Core.BlackJack;
using CardGames.Core.PlayingCards;
using NUnit.Framework;
using System.Collections.Generic;

namespace CardGames.Tests.BlackJack
{
    [TestFixture]
    public class BlackJackDealerAiTests
    {
        [Test]
        public void ShouldHit_AllPlayersBust_False()
        {
            var players = new List<BlackJackHand>
            {
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen, FaceType.Five),
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen, FaceType.Five)
            };

            var dealer = BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen);

            var ai = new BlackJackDealerAi(players, dealer);

            var result = ai.ShouldHit();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldHit_DealerBust_False()
        {
            var players = new List<BlackJackHand>
            {
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Five),
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Five)
            };

            var dealer = BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen, FaceType.Eight);

            var ai = new BlackJackDealerAi(players, dealer);

            var result = ai.ShouldHit();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldHit_DealerWinning_False()
        {
            var players = new List<BlackJackHand>
            {
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Five),
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Eight)
            };

            var dealer = BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Nine);

            var ai = new BlackJackDealerAi(players, dealer);

            var result = ai.ShouldHit();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ShouldHit_PlayerWinning_True()
        {
            var players = new List<BlackJackHand>
            {
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen, FaceType.Five),
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Nine)
            };

            var dealer = BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Eight);

            var ai = new BlackJackDealerAi(players, dealer);

            var result = ai.ShouldHit();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ShouldHit_TopPlayerTie_False()
        {
            var players = new List<BlackJackHand>
            {
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Queen, FaceType.Five),
                BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Nine)
            };

            var dealer = BlackJackHandHelper.SimpleHand(FaceType.King, FaceType.Nine);

            var ai = new BlackJackDealerAi(players, dealer);

            var result = ai.ShouldHit();

            Assert.AreEqual(false, result);
        }
    }
}
