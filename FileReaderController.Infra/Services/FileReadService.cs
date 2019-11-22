using System.IO;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class FileReadService : IFileReadService
    {
        public string _filePath { get; private set; }
        public string _fileName { get; private set; }

        public FileReadService(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public string[] GetLinesFromFile() => File.ReadAllLines(Path.Combine(_filePath, _fileName));

    }
}