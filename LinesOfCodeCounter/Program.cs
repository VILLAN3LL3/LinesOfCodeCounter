using LinesOfCodeCounter.Model;
using LinesOfCodeCounter.UI;

namespace LinesOfCodeCounter
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var consoleUi = new ConsoleUi(new ConsoleWrapper());
            var interactor = new Interactor();
            int totalLinesCount = 0;
            int totalLinesOfCodeCount = 0;
            string directory = args[0];

            foreach (LinesOfCodeStat stat in interactor.GetLinesOfCodeStats(directory))
            {
                totalLinesCount += stat.LinesCount;
                totalLinesOfCodeCount += stat.LinesOfCodeCount;
                consoleUi.PrintLinesOfCodeStatToConsole(stat);
            }

            consoleUi.PrintLinesOfCodeSummaryToConsole(new LinesOfCodeSummary(totalLinesCount, totalLinesOfCodeCount));
            consoleUi.WaitForInput();
        }
    }
}
