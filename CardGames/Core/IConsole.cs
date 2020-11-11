using System;

namespace CardGames.Core
{
    public interface IConsole
    {
        void Write(string str);

        void WriteLine(string str);

        ConsoleKeyInfo ReadKey(bool intercept);
    }
}
