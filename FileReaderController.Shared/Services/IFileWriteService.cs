namespace FileReaderController.Shared.Services
{    
    public interface IFileWriteService
    {
        void CreateFileFromLines(string[] lines, string filePath, string fileName);
    }
}