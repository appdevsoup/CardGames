namespace CardGames.Core.BlackJack
{
    //this is used for means of mocking the dealer Ai in tests
    public interface IBlackJackDealerAi
    {
        bool ShouldHit();
    }
}
