using FileReaderController.Application.Commands;
using FileReaderController.Application.Helpers;
using FileReaderController.Application.Helpers.ToObject;
using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Commands;
using FileReaderController.Shared.Enums;
using FileReaderController.Shared.Hendlers;
using FileReaderController.Shared.Services;
using System;
using System.Collections.Generic;

namespace FileReaderController.Application.Handlers
{
    public class ImportFileHendler : IHendler<ImportFileCommand>
    {
        IConvertToObject<Client> convertToClient;
        IConvertToObject<Salesman> convertToSalesman;
        IConvertToObject<SalesData> convertToSalesdata;
        FileReadSalesBase fileReadSales;
        IFileWriteService _fileWriteServices;


        public ImportFileHendler(IFileWriteService fileWriteServices)
        {
            convertToClient = new ConvertToClient();
            convertToSalesman = new ConvertToSalesman();
            convertToSalesdata = new ConvertToSalesData();

            _fileWriteServices = fileWriteServices;
        }

        public ICommandResult ExecuteHendler(ImportFileCommand command)
        {
            if (command.IsValid)
            {
                var fileControllerReturn = new List<string>();

                fileReadSales = new FileReadSalesBase(command.FileName, DateTime.Now);

                if (fileReadSales.Invalid)
                    return new CommandResult(false, fileReadSales.AddErrorFromNotifications());

                foreach (string line in command.FileReader)
                {
                    ELineType lineType = ImportFileHelper.IdentifyLineType(line);
                    string errorReturn = string.Empty;

                    switch (lineType)
                    {
                        case ELineType.ClienteData:
                            Client cli = convertToClient.ExecuteConversion(line);

                            if (cli.Invalid)
                                errorReturn = cli.AddErrorFromNotifications();

                            fileReadSales.AddClient(cli);
                            break;
                        case ELineType.SalesData:
                            SalesData sale = convertToSalesdata.ExecuteConversion(line);

                            if (sale.Invalid)
                                errorReturn = sale.AddErrorFromNotifications();

                            fileReadSales.AddSales(sale);
                            break;
                        case ELineType.SalesmanData:
                            Salesman salesman = convertToSalesman.ExecuteConversion(line);

                            if (salesman.Invalid)
                                errorReturn = salesman.AddErrorFromNotifications();

                            fileReadSales.AddSalesman(salesman);
                            break;
                    }

                    fileControllerReturn.Add($"{line} => {errorReturn}");

                }

                var linesOutFile = fileReadSales.WriteFileLines();
                _fileWriteServices.WriteFileFromLines(lines: linesOutFile, filePath: command.FilePath, fileName: command.FileName);
                _fileWriteServices.WriteFileFromLines(lines: fileControllerReturn.ToArray(), filePath: command.FilePath, fileName: $"{command.FileName}.RET");

            }

            return new CommandResult(true, "Dados importados com sucesso");
        }
    }
}