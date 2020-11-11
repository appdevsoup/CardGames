using CardGames.Core.PlayingCards;
using CardGames.Exceptions;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace CardGames.Tests.PlayingCards
{
    [TestFixture]
    public class PlayingCardDeckTests
    {
        [Test]
        public void CreateDeck_TotalCards52()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var result = deck.Cards.Count;

            Assert.AreEqual(52, result, 0);
        }

        [Test]
        [TestCase(SuitType.Diamond, 13, TestName = "CreateDeck_DiamondSuitCheck")]
        [TestCase(SuitType.Club, 13, TestName = "CreateDeck_ClubSuitCheck")]
        [TestCase(SuitType.Spade, 13, TestName = "CreateDeck_SpadeSuitCheck")]
        [TestCase(SuitType.Heart, 13, TestName = "CreateDeck_HeartSuitCheck")]
        public void CreateDeck_VariousSuitCountCheck(SuitType suit, int expectedValue)
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var result = deck.Cards.Count(c => c.Suit == suit);

            Assert.AreEqual(expectedValue, result, 0);
        }

        [Test]
        [TestCase(FaceType.Two, 4, TestName = "CreateDeck_TwoFaceCheck")]
        [TestCase(FaceType.Three, 4, TestName = "CreateDeck_ThreeFaceCheck")]
        [TestCase(FaceType.Four, 4, TestName = "CreateDeck_FourFaceCheck")]
        [TestCase(FaceType.Five, 4, TestName = "CreateDeck_FiveFaceCheck")]
        [TestCase(FaceType.Six, 4, TestName = "CreateDeck_SixFaceCheck")]
        [TestCase(FaceType.Seven, 4, TestName = "CreateDeck_SevenFaceCheck")]
        [TestCase(FaceType.Eight, 4, TestName = "CreateDeck_EightFaceCheck")]
        [TestCase(FaceType.Nine, 4, TestName = "CreateDeck_NineFaceCheck")]
        [TestCase(FaceType.Ten, 4, TestName = "CreateDeck_TenFaceCheck")]
        [TestCase(FaceType.Jack, 4, TestName = "CreateDeck_JackFaceCheck")]
        [TestCase(FaceType.Queen, 4, TestName = "CreateDeck_QueenFaceCheck")]
        [TestCase(FaceType.King, 4, TestName = "CreateDeck_KingFaceCheck")]
        [TestCase(FaceType.Ace, 4, TestName = "CreateDeck_AceFaceCheck")]
        public void CreateDeck_VariousFaceCountCheck(FaceType face, int expectedValue)
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var result = deck.Cards.Count(c => c.Face == face);

            Assert.AreEqual(expectedValue, result, 0);
        }

        [Test]
        public void DrawCard_TakenOffTopOfDeck()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var expectedValue = deck.Cards.Last();

            var result = deck.DrawCard();

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void DrawCard_CardIsRemovedFromDeck()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var card = deck.DrawCard();

            Assert.IsFalse(deck.Cards.Any(c => c == card));
        }

        [Test]
        public void DrawCard_NoneAvailable()
        {
            var deck = new PlayingCardDeck();

            Assert.Throws<NoAvailableCardsException>(() => deck.DrawCard());
        }


        [Test]
        public void Shuffle_DeckSignatureChanged()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var initialSignature = CreateDeckSignature(deck);

            deck.Shuffle();

            var resultSignature = CreateDeckSignature(deck);

            Assert.AreNotEqual(initialSignature, resultSignature);
        }

        [Test]
        public void AddCardToBottom_CardIsAddedToBottom()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var card = new PlayingCard(SuitType.Heart, FaceType.Queen);

            deck.AddCardToBottom(card);

            var result = deck.Cards.First();

            Assert.AreEqual(card, result);
        }

        [Test]
        public void AddCardToBottom_CardAlreadyExists()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var card = deck.Cards.First();

            Assert.Throws<CardAlreadyExistsInCollectionException>(() => deck.AddCardToBottom(card));
        }

        [Test]
        public void ClearCards_CardsAreRemoved()
        {
            var deck = new PlayingCardDeck();

            deck.AddCards();

            var result = deck.Cards.Count;

            Assert.AreEqual(52, result, 0);

            deck.ClearCards();

            result = deck.Cards.Count;

            Assert.AreEqual(0, result, 0);
        }

        private static string CreateDeckSignature(PlayingCardDeck deck)
        {
            var stringBuilder = new StringBuilder();

            foreach (var card in deck.Cards)
            {
                stringBuilder.Append($"{card}");
            }

            return stringBuilder.ToString();
        }
    }
}
