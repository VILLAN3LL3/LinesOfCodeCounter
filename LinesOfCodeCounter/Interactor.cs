using System.Collections.Generic;
using LinesOfCodeCounter.Domain;
using LinesOfCodeCounter.IO;
using LinesOfCodeCounter.Model;

namespace LinesOfCodeCounter
{
    public class Interactor
    {
        public IEnumerable<LinesOfCodeStat> GetLinesOfCodeStats(string directory)
        {
            var fileCrawler = new FileCrawler(new DirectoryReader());
            var fileReader = new FileReader();
            var lineCounter = new LineCounter();

            foreach (string filePath in fileCrawler.FindSourceFileNames(directory))
            {
                string[] lines = fileReader.ReadLinesFromFile(filePath);
                int linesCount = lineCounter.CountLines(lines);
                int linesOfCodeCount = lineCounter.CountLinesOfCode(lines);
                yield return new LinesOfCodeStat(filePath, linesCount, linesOfCodeCount);
            }
        }
    }
}
