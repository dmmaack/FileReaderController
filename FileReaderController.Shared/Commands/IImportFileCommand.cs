namespace FileReaderController.Shared.Commands
{
    public interface IImportFileCommand
    {
        string FileName { get; set; }
    }
}