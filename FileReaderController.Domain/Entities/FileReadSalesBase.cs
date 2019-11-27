using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace FileReaderController.Domain.Entities
{
    public class FileReadSalesBase : Notifiable
    {
        private IList<Client> clientList;
        private IList<SalesData> salesList;
        private IList<Salesman> salesmanList;

        public FileReadSalesBase(string fileName, DateTime importDate)
        {
            FileName = fileName;
            ImportDate = importDate;
            Message = string.Empty;
            HasError = false;

            clientList = new List<Client>();
            salesList = new List<SalesData>();
            salesmanList = new List<Salesman>();

            AddNotifications(new Contract().Requires()
            .HasMinLen(fileName, 3, "FileReadSalesBase.FileName", "Nome do Arquivo contem menos de 3 caracteres.")
            .IsTrue(FileNameValidation(), "FileReadSalesBase.FileName", "Sequencial do Nome do Arquivo fora do padrao"));
        }

        public int Id { get; private set; }
        public string FileName { get; private set; }
        public DateTime ImportDate { get; private set; }
        public string Message { get; private set; }
        public bool HasError { get; private set; }

        public ICollection<Client> ClientList { get => clientList.ToList(); }
        public ICollection<SalesData> SalesList { get => salesList.ToList(); }
        public ICollection<Salesman> SalesmanList { get => salesmanList.ToList(); }

        public void AddClient(Client client)
        {
            if (!clientList.Contains(client))
                clientList.Add(client);
        }

        public void AddSales(SalesData sales)
        {
            if (!salesList.Contains(sales))
                salesList.Add(sales);
        }

        public void AddSalesman(Salesman salesman)
        {
            if (!salesmanList.Contains(salesman))
                salesmanList.Add(salesman);
        }

        private bool FileNameValidation()
        {
            string seq = DateTime.Now.ToString("yyyyMMdd");
            string name = FileName.Split('.')[0];
            return name.EndsWith(seq);
        }

        public string[] WriteFileLines()
        {
            List<string> content = new List<string>();
            int clientsWithErrors = ClientQuantityWithErrors;
            int clientsWithoutErrors = ClientQuantityWithoutErrors;

            int salesmanWithErrors = SalesmanQuantityWithErrors;
            int salesmanWithoutErrors = SalesmanQuantityWithoutErrors;

            content.Add($"Total de Clientes: {clientsWithErrors + clientsWithoutErrors}");
            content.Add($"Total de Clientes c/ erros: {clientsWithErrors}");
            content.Add($"Total de Clientes s/ erros: {clientsWithoutErrors}");
            content.Add(Environment.NewLine);
            content.Add($"Total de Vendedores: {salesmanWithErrors + salesmanWithoutErrors}");
            content.Add($"Total de Vendedores c/ erros: {salesmanWithErrors}");
            content.Add($"Total de Vendedores s/ erros: {salesmanWithoutErrors}");
            content.Add(Environment.NewLine);
            content.Add($"Maior venda:");
            content.Add(GetBiggestSale());

            return content.ToArray();
        }

        private bool ImportDateValidation() => ImportDate.Date < DateTime.Now.Date;

        private int ClientQuantityWithErrors => ClientList.Count(c => c.HasError);
        private int ClientQuantityWithoutErrors => ClientList.Count(c => !c.HasError);

        private int SalesmanQuantityWithErrors => SalesmanList.Count(c => c.HasError);
        private int SalesmanQuantityWithoutErrors => SalesmanList.Count(c => !c.HasError);

        private int SalesQuantityWithErrors => SalesList.Count(c => c.HasError);
        private int SalesQuantityWithoutErrors => SalesList.Count(c => !c.HasError);


        private string GetBiggestSale()
        {
            var salesInfo = SalesList.Select(s =>
                                                new
                                                {
                                                    Salesman = s.SalesmanName,
                                                    Price = s.SalesItemList.Max(m => m.ItemPrice)
                                                }
                                                                                )
                                                                                .Aggregate((sales1, sales2) => sales1.Price > sales2.Price ? sales1 : sales2);

            return $"Vendedor: {salesInfo.Salesman} - Valor venda: {salesInfo.Price}";
        }        

        public void AddErrorMessage(string message, bool hasError)
        {
            Message = message;
            HasError = hasError;
        }

        public string AddErrorFromNotifications()
        {
            var notifications = this.Notifications
                                .Select(s => $"{s.Property}-{s.Message}")
                                .ToArray()
                                .Aggregate((current, next) => $"{current} | {next}");


            AddErrorMessage(notifications, true);

            return notifications;
        }


    }
}