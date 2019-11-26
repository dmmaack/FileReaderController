namespace FileReaderController.Shared.Services
{    
    public interface IDirectoryReadService
    {
        string[] GetFiles();
        bool HasFiles();
        bool ValidateDirectory();
    }
}