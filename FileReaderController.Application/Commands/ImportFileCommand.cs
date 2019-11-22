using FileReaderController.Shared.Commands;

namespace FileReaderController.Application.Commands
{
    public class ImportFileCommand : CommandBase, IImportFileCommand
    {
        public string FileName { get; set; }
    }
}