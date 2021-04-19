using System;
using System.Text;
using LinesOfCodeCounter.UI;

namespace LinesOfCodeCounter.Tests
{
    internal class MockConsoleWrapper : IConsole
    {
        public StringBuilder MockConsole { get; } = new StringBuilder();

        public void WriteLine(string message) => MockConsole.AppendLine(message);

        public string ReadLine() => throw new NotImplementedException();
    }
}
