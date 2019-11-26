using System.IO;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class FileReadService : IFileReadService
    {  
        public string[] GetLinesFromFile(string filePath, string fileName)
        {
            string fileToRead = Path.Combine(filePath, fileName);
            string fileToMove = Path.Combine(Path.Combine(filePath, "Processed"), fileName);

            var linesReaded = File.ReadAllLines(fileToRead);

            File.Move(fileToRead, fileToMove);

            return linesReaded;
        }

    }
}