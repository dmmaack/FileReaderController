using System.Collections.Generic;
using FileReaderController.Shared.Enums;
using Flunt.Validations;

namespace FileReaderController.Domain.Entities
{
    public class SalesData : EntitieBase
    {
        private IList<SalesItemData> salesItemList;

        public SalesData(ELineType lineType, string saleId, string salesmanName) : base(lineType)
        {
            SaleId = saleId;
            SalesmanName = salesmanName;

            salesItemList = new List<SalesItemData>();

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(salesmanName, "SalesData.SalesmanName", "Informacao nao definida"));
        }

        public string SaleId { get; private set; }
        public string SalesmanName { get; private set; }
        public ICollection<SalesItemData> SalesItemList { get => salesItemList; }

        public void AddItens(SalesItemData item)
        {
            if (!salesItemList.Contains(item))
                salesItemList.Add(item);
        }

    }
}