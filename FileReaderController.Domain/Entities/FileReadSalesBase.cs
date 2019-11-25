using System;
using System.Collections.Generic;
using System.Linq;

namespace FileReaderController.Domain.Entities
{
    public class FileReadSalesBase
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
        }

        public int Id { get; private set; }
        public string FileName { get; private set; }
        public DateTime ImportDate { get; private set; }
        public string Message { get; private set; }
        public bool HasError { get; private set; }

        public ICollection<Client> ClientList { get => clientList.ToList(); }
        public ICollection<SalesData> SalesList { get => salesList.ToList(); }
        public ICollection<Salesman> SalesmanList { get => salesmanList.ToList(); }

        public void AddError(string message, bool hasError) {
            HasError = hasError;
            Message = message;
        }

        public void AddClient(Client client){
            if(!clientList.Contains(client))
                clientList.Add(client);
        }

        public void AddSales(SalesData sales){
            if(salesList.Contains(sales))
                salesList.Add(sales);
        }

        public void AddSalesman(Salesman salesman){
            if(salesmanList.Contains(salesman))
                salesmanList.Add(salesman);
        }


    }
}