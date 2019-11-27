using System.IO;
using FileReaderController.App;
using FileReaderController.Application.Commands;
using FileReaderController.Application.Handlers;
using FileReaderController.Infra.Services;
using FileReaderController.Shared.Hendlers;
using FileReaderController.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderController.Tests.App
{
    [TestClass]
    public class FileAppTests
    {
        public static IConfigurationRoot Configuration { get; set; }
        
        public FileAppTests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        [TestMethod]
        public void ExecuteAppTest()
        {
            IFileWriteService fileWriteServices = new FileWriteService();
            IHendler<ImportFileCommand> importFileHendler = new ImportFileHendler(fileWriteServices);
            IFileReadService fileReadService = new FileReadService();

            string retorno = new ImportFileApp(importFileHendler, fileReadService, Configuration).ImportFile();
        }

    }
}