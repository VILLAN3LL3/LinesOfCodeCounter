using System.Text;

namespace LinesOfCodeCounter.Tests
{
    internal class MockConsoleWrapper : IConsole
    {
        public StringBuilder MockConsole { get; } = new StringBuilder();

        public void WriteLine(string message) => MockConsole.AppendLine(message);
    }
}
