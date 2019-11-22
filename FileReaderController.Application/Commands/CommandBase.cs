using FileReaderController.Shared.Commands;

namespace FileReaderController.Application.Commands
{
    public abstract class CommandBase : ICommandBase
    {
        public string[] FileReader { get; set; }

        public virtual bool IsValid => Validate();

        protected virtual bool Validate() => FileReader.Length > 0;
    }
}