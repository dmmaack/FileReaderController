using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using FileReaderController.Shared.Hendlers;
using FileReaderController.Application.Commands;
using FileReaderController.Application.Handlers;
using FileReaderController.Infra.Services;
using FileReaderController.Shared.Services;

namespace FileReaderController.App
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        static void ExecuteApp()
        {
            IFileWriteService fileWriteServices = new FileWriteService();
            IHendler<ImportFileCommand> importFileHendler = new ImportFileHendler(fileWriteServices);
            IFileReadService fileReadService = new FileReadService();

            Console.WriteLine(new ImportFileApp(importFileHendler, fileReadService, Configuration).ImportFile());
        }
    }
}
