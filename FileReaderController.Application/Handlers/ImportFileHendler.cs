using FileReaderController.Application.Commands;
using FileReaderController.Application.Helpers;
using FileReaderController.Shared.Commands;
using FileReaderController.Shared.Enums;
using FileReaderController.Shared.Hendlers;
using System.Linq;

namespace FileReaderController.Application.Handlers
{
    public class ImportFileHendler : IHendler<ImportFileCommand>
    {
        public ImportFileHendler()
        {

        }

        public ICommandResult ExecuteHendler(ImportFileCommand command)
        {
            if (command.IsValid)
            {
                foreach (string line in command.FileReader)
                {
                    ELineType lineType = ImportFileHelper.IdentifyLineType(line);

                    switch(lineType){
                        case ELineType.ClienteData:
                            
                        break;
                        case ELineType.SalesData:

                        break;
                        case ELineType.SalesmanData:

                        break;
                    }
                }
            }

            return new CommandResult();
        }
    }
}