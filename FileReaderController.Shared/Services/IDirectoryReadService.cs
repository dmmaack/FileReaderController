namespace FileReaderController.Shared.Services
{    
    public interface IDirectoryReadService
    {
        string _filePath { get; }

        bool HasFiles();
        bool ValidateDirectory();
    }
}