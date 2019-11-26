namespace FileReaderController.Shared.Services
{    
    public interface IFileWriteService
    {
        void WriteFileFromLines(string[] lines, string filePath, string fileName);
    }
}