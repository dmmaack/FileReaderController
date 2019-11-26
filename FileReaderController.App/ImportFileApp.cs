using FileReaderController.Shared.Hendlers;
using FileReaderController.Application.Commands;
using FileReaderController.Shared.Services;
using Microsoft.Extensions.Configuration;
using FileReaderController.Infra.Services;

namespace FileReaderController.App
{
    public class ImportFileApp
    {
        private IHendler<ImportFileCommand> _importFileHendler { get; set; }
        private IFileWriteService _fileWriteServices { get; set; }
        private IFileReadService _fileReadService { get; set; }
        private IDirectoryReadService _directoryReadService { get; set; }
        private string _dirIn { get; set; }
        private string _dirOut { get; set; }

        public ImportFileApp(IHendler<ImportFileCommand> importFileHendler,
                             IFileReadService fileReadService, IConfigurationRoot configuration)
        {
            this._importFileHendler = importFileHendler;
            this._fileReadService = fileReadService;

            _dirIn = configuration["ImportDirectoryInput"];
            _dirOut = configuration["ImportDirectoryOutput"];

            this._directoryReadService = new DirectoryReadService(_dirIn);
        }

        public string ImportFile()
        {
            bool hasFiles = false;

            if (_directoryReadService.ValidateDirectory())
                hasFiles = _directoryReadService.HasFiles();

            if (hasFiles)
            {
                string[] files = _directoryReadService.GetFiles();

                foreach (var item in files)
                {
                    string[] fileArray = item.Split("/");
                    string fileName = fileArray[fileArray.Length-1];

                    string[] lines = _fileReadService.GetLinesFromFile(_dirIn, fileName);

                    var command = new ImportFileCommand()
                    {
                        FileName = fileName,
                        FilePath = _dirOut,
                        FileReader = lines,
                    };

                    var result = _importFileHendler.ExecuteHendler(command);

                    return $"Sucess: {result.Sucess} - Mensagem: {result.Message}";
                }
            }

            return $"Sucess: {hasFiles} - Mensagem: Arquivos Inexistentes";

        }





    }
}