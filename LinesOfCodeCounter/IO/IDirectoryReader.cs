namespace LinesOfCodeCounter.IO
{
    public interface IDirectoryReader
    {
        string[] GetFiles(string path, string searchPattern);

        string[] GetDirectories(string path);
    }
}
