using System.IO;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class FileWriteService : IFileWriteService
    {
        public void CreateFileFromLines(string[] linhas, string filePath, string fileName) => File.WriteAllLines(Path.Combine(filePath, fileName), linhas);
    }
}