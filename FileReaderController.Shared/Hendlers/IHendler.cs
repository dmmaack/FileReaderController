using FileReaderController.Shared.Commands;

namespace FileReaderController.Shared.Hendlers
{
    public interface IHendler<T> where T : ICommandBase
    {
        ICommandResult ExecuteHendler(T command);
    }
}