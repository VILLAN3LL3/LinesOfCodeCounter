using System.Linq;

namespace LinesOfCodeCounter.Domain
{
    public class LineCounter
    {
        public int CountLines(string[] lines) => lines.Length;

        public int CountLinesOfCode(string[] lines) => lines
            .Count(line =>
                   !IsEmptyLine(line)
                && !IsComment(line));

        private bool IsEmptyLine(string line) => string.IsNullOrWhiteSpace(line);
        private bool IsComment(string line) => line.TrimStart().StartsWith("//");
    }
}
