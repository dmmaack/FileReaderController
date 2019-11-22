using System.IO;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class DirectoryReadService : IDirectoryReadService
    {
        public string _filePath { get; private set; }

        public DirectoryReadService(string filePath)
        {
            _filePath = filePath;
        }

        public bool ValidateDirectory() => (new DirectoryInfo(_filePath)).Exists;

        public bool HasFiles() => (ValidateDirectory() ? new DirectoryInfo(_filePath).GetFiles().Length > 0 : false);

    }
}