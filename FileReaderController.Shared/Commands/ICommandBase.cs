namespace FileReaderController.Shared.Commands
{    
    public interface ICommandBase
    {
        string[] FileReader { get; set; }
        bool IsValid { get; }
    }
}