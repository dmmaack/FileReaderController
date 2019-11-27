using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using FileReaderController.Shared.Hendlers;
using FileReaderController.Application.Commands;
using FileReaderController.Application.Handlers;
using FileReaderController.Infra.Services;
using FileReaderController.Shared.Services;
using System.Diagnostics;

namespace FileReaderController.App
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        protected static bool Exit { get; set; }
        protected static int Count { get; set; }

        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--kill")
                KillProcess();

            if (Process.GetProcessesByName("FileReaderController.App").Length > 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Outro processo de FileReaderController está sendo executado, é necessário encerra-lo antes de executar um novo.");
                Console.WriteLine("Deseja encerra-lo? (s/n): ");

                string readLine = Console.ReadLine();

                if (readLine.ToLower().Equals("s"))
                    KillProcess();
                else
                    Process.GetCurrentProcess().Kill();
            }

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            ExecuteApp();
        }

        static void ExecuteApp()
        {
            IFileWriteService fileWriteServices = new FileWriteService();
            IHendler<ImportFileCommand> importFileHendler = new ImportFileHendler(fileWriteServices);
            IFileReadService fileReadService = new FileReadService();

            do
            {
                Count++;

                Console.Clear();
                Console.WriteLine($"Processamento iniciado: {Count}");

                Console.WriteLine(new ImportFileApp(importFileHendler, fileReadService, Configuration).ImportFile());

                Console.WriteLine("Processamento finalizado.");
                Console.WriteLine("Deseja encerrar o Aplicativo? (s/n): ");

                string readLine;
                bool sucess = LineReader.TryReadLine(out readLine, int.Parse(Configuration["TimingToExecute"]));

                if (sucess)
                {
                    if (readLine.ToLower().Equals("s"))
                        Exit = true;
                }

            } while (!Exit);

            Process.GetCurrentProcess().Kill();
        }

        private static void KillProcess()
        {
            var processes = Process.GetProcessesByName("FileReaderController.App");
            foreach (var p in processes)
                p.Kill();
        }
    }
}
