using System.ComponentModel;

namespace CardGames.Core.PlayingCards
{
    public enum SuitType
    {
        [Description("H")]
        Heart = 1,

        [Description("D")]
        Diamond = 2,

        [Description("S")]
        Spade = 3,

        [Description("C")]
        Club = 4
    }
}
