using CardGames.Core;
using CardGames.Core.BlackJack;
using System.Diagnostics.CodeAnalysis;

namespace CardGames
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            var engine = new BlackJackGameEngine(new ConsoleWrapper());

            engine.Start();
        }
    }
}
