using FileReaderController.Shared.Commands;

namespace FileReaderController.Application.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public bool Sucess { get; private set; }
        public string Message { get; private set; }
    }
}