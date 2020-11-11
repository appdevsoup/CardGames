using System;
using System.Diagnostics.CodeAnalysis;

namespace CardGames.Core
{
    //This exists strictly as a means to inject and test console output

    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsole
    {
        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }
    }
}
