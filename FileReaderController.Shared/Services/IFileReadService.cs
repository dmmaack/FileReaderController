namespace FileReaderController.Shared.Services
{
    
    public interface IFileReadService
    {
        string[] GetLinesFromFile(string filePath, string fileName);
    }
}