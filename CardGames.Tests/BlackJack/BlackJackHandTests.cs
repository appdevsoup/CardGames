using CardGames.Core.PlayingCards;
using CardGames.Exceptions;
using NUnit.Framework;

namespace CardGames.Tests.BlackJack
{
    [TestFixture]
    public class BlackJackHandTests
    {
        [Test]
        [TestCase(FaceType.Two, 2, TestName = "CalculateValue_SimpleTwoCard")]
        [TestCase(FaceType.Three, 3, TestName = "CalculateValue_SimpleThreeCard")]
        [TestCase(FaceType.Four, 4, TestName = "CalculateValue_SimpleFourCard")]
        [TestCase(FaceType.Five, 5, TestName = "CalculateValue_SimpleFiveCard")]
        [TestCase(FaceType.Six, 6, TestName = "CalculateValue_SimpleSixCard")]
        [TestCase(FaceType.Seven, 7, TestName = "CalculateValue_SimpleSevenCard")]
        [TestCase(FaceType.Eight, 8, TestName = "CalculateValue_SimpleEightCard")]
        [TestCase(FaceType.Nine, 9, TestName = "CalculateValue_SimpleNineCard")]
        [TestCase(FaceType.Ten, 10, TestName = "CalculateValue_SimpleTenCard")]
        [TestCase(FaceType.Jack, 10, TestName = "CalculateValue_SimpleJackCard")]
        [TestCase(FaceType.Queen, 10, TestName = "CalculateValue_SimpleQueenCard")]
        [TestCase(FaceType.King, 10, TestName = "CalculateValue_SimpleKingCard")]
        [TestCase(FaceType.Ace, 11, TestName = "CalculateValue_SimpleAceCard")]
        public void CalculateValue_SimpleVariousScenarios(FaceType face, int expectedValue)
        {
            var hand = BlackJackHandHelper.SimpleHand(face);

            var result = hand.CalculateValue();

            Assert.AreEqual(expectedValue, result, 0);
        }

        [Test]
        [TestCase(FaceType.Ace, FaceType.Ace, 12, TestName = "CalculateValue_DoubleAceCards")]
        [TestCase(FaceType.King, FaceType.Ace, 21, TestName = "CalculateValue_PerfectBlackJackCards")]
        public void CalculateValue_TwoCardScenarios(FaceType face, FaceType face2, int expectedValue)
        {
            var hand = BlackJackHandHelper.SimpleHand(face, face2);

            var result = hand.CalculateValue();

            Assert.AreEqual(expectedValue, result, 0);
        }

        [Test]
        [TestCase(FaceType.Ace, FaceType.Ace, FaceType.Ace, 13, TestName = "CalculateValue_TripleAceCards")]
        [TestCase(FaceType.Five, FaceType.Ten, FaceType.Ace, 16, TestName = "CalculateValue_AceAsOneCards")]
        [TestCase(FaceType.King, FaceType.Jack, FaceType.Ace, 21, TestName = "CalculateValue_RareBlackJackCards")]
        public void CalculateValue_ThreeCardScenarios(FaceType face, FaceType face2, FaceType face3, int expectedValue)
        {
            var hand = BlackJackHandHelper.SimpleHand(face, face2, face3);

            var result = hand.CalculateValue();

            Assert.AreEqual(expectedValue, result, 0);
        }

        [Test]
        [TestCase(FaceType.King, FaceType.King, FaceType.King, true, TestName = "IsBust_ClearOver")]
        [TestCase(FaceType.King, FaceType.Queen, FaceType.Ace, false, TestName = "IsBust_BlackJack")]
        [TestCase(FaceType.Two, FaceType.Two, FaceType.Two, false, TestName = "IsBust_ClearUnder")]
        public void IsBust_VariousScenarios(FaceType face, FaceType face2, FaceType face3, bool expectedValue)
        {
            var hand = BlackJackHandHelper.SimpleHand(face, face2, face3);

            var result = hand.IsBust;

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void RemoveCard_SuccessfullyRemoveCard()
        {
            var hand = BlackJackHandHelper.SimpleHand(FaceType.King);
            var card = new PlayingCard(SuitType.Heart, FaceType.Ace);

            hand.AddCard(card);

            Assert.AreEqual(2, hand.Cards.Count);

            hand.RemoveCard(card);

            Assert.AreEqual(1, hand.Cards.Count);
        }

        [Test]
        public void RemoveCard_RemoveCardDoesNotExist()
        {
            var hand = BlackJackHandHelper.SimpleHand(FaceType.King);

            var card = new PlayingCard(SuitType.Heart, FaceType.Ace);

            Assert.Throws<CardDoesNotExistInCollectionException>(() => hand.RemoveCard(card));
        }

        [Test]
        public void AddCard_CardAlreadyExist()
        {
            var hand = BlackJackHandHelper.SimpleHand(FaceType.King);
            var card = new PlayingCard(SuitType.Heart, FaceType.Ace);

            hand.AddCard(card);

            Assert.AreEqual(2, hand.Cards.Count);

            Assert.Throws<CardAlreadyExistsInCollectionException>(() => hand.AddCard(card));
        }
    }
}
