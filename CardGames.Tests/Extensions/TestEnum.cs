namespace CardGames.Tests.Extensions
{
    public enum TestEnum
    {
        NoDescription = 0,

        [System.ComponentModel.Description("Has Description")]
        HasDescription = 1
    }
}
