using LinesOfCodeCounter.Model;

namespace LinesOfCodeCounter.UI
{
    public class ConsoleUi
    {
        private readonly IConsole _console;

        public ConsoleUi(IConsole console) => _console = console;

        public void PrintLinesOfCodeStatToConsole(LinesOfCodeStat linesOfCodeStat) => _console.WriteLine($"{linesOfCodeStat.FilePath} {linesOfCodeStat.LinesCount} {linesOfCodeStat.LinesOfCodeCount}");

        public void PrintLinesOfCodeSummaryToConsole(LinesOfCodeSummary linesOfCodeSummary)
        {
            _console.WriteLine("Total");
            _console.WriteLine($"   Lines {FormatIntWithThousandSeparator(linesOfCodeSummary.TotalLinesCount)}");
            _console.WriteLine($"   Lines of Code {FormatIntWithThousandSeparator(linesOfCodeSummary.TotalLinesOfCodeCount)}");
        }

        private string FormatIntWithThousandSeparator(int value) => string.Format("{0:n0}", value);

        public void WaitForInput() => _console.ReadLine();
    }
}
