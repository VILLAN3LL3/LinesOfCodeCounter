using System;

namespace LinesOfCodeCounter.UI
{
    internal class ConsoleWrapper : IConsole
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
