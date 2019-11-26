using System.IO;
using System.Linq;
using FileReaderController.Shared.Services;

namespace FileReaderController.Infra.Services
{
    public class DirectoryReadService : IDirectoryReadService
    {
        private string _filePath;

        public DirectoryReadService(string filePath) => _filePath = filePath;

        public bool ValidateDirectory() => (new DirectoryInfo(_filePath)).Exists;

        public bool HasFiles() => (ValidateDirectory() ? new DirectoryInfo(_filePath).GetFiles().Length > 0 : false);

        public string[] GetFiles() => new DirectoryInfo(_filePath).GetFiles().Select(s => s.FullName).ToArray();
            
        

    }
}