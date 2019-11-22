namespace FileReaderController.Shared.Commands
{    
    public interface ICommandResult
    {
        bool Sucess { get; }
        string Message { get; }
    }
}