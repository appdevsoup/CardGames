using CardGames.Core;
using System;

namespace CardGames.Tests
{
    //a simple test console that allows some collection of output for writes
    //and a controlled input for the read key. Yes, this could likely be done
    //via moq, but i found this to be a faster, easier approach overall.

    public class TestConsole : IConsole
    {
        private readonly ConsoleKeyInfo _info;

        public TestConsole(ConsoleKeyInfo info)
        {
            _info = info;
        }

        public TestConsole()
        {
        }

        public string Result { get; private set; } = string.Empty;


        public void Write(string str)
        {
            Result += str;
        }

        public void WriteLine(string str)
        {
            Result += str + "\n";
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return _info;
        }
    }
}
