using System.IO;

namespace LinesOfCodeCounter.IO
{
    internal class DirectoryReader : IDirectoryReader
    {
        public string[] GetDirectories(string path) => Directory.GetDirectories(path);
        public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);
    }
}
