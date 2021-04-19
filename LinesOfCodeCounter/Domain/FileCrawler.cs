using System.Collections.Generic;
using LinesOfCodeCounter.IO;

namespace LinesOfCodeCounter.Domain
{
    public class FileCrawler
    {
        private readonly IDirectoryReader _directoryReader;

        public FileCrawler(IDirectoryReader directoryReader)
        {
            _directoryReader = directoryReader;
        }

        public IEnumerable<string> FindSourceFileNames(string directory)
        {
            foreach (string filePath in _directoryReader.GetFiles(directory, "*.cs"))
            {
                yield return filePath;
            }
            foreach (string directoryPath in _directoryReader.GetDirectories(directory))
            {
                foreach (string filePath in FindSourceFileNames(directoryPath))
                {
                    yield return filePath;
                }
            }
        }
    }
}
