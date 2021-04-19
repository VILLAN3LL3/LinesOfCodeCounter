using System;
using System.IO;

namespace LinesOfCodeCounter.IO
{
    public class FileReader
    {
        public string[] ReadLinesFromFile(string filePath) => string.IsNullOrWhiteSpace(filePath) ? Array.Empty<string>() : File.ReadAllLines(filePath);
    }
}
