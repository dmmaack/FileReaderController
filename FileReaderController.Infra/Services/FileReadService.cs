using System.IO;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class FileReadService : IFileReadService
    {
        public string[] GetLinesFromFile(string filePath, string fileName)
        {
            string fileToRead = Path.Combine(filePath, fileName);
            string pathToMove = Path.Combine(filePath, "Processed");

            var dirToMove = new DirectoryInfo(pathToMove);

            if (!dirToMove.Exists)
                dirToMove.Create();

            string pathFileToMove = Path.Combine(Path.Combine(filePath, "Processed"), fileName);

            var linesReaded = File.ReadAllLines(fileToRead);

            var fileToMove = new FileInfo(pathFileToMove);

            if (fileToMove.Exists)
                fileToMove.Delete();

            File.Move(fileToRead, pathFileToMove);

            return linesReaded;
        }

    }
}