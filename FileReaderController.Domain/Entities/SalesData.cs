using System.Collections.Generic;
using System.Linq;
using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Domain.Entities
{
    public class SalesData : EntitieBase
    {
        private IList<SalesItemData> salesItemList;

        public SalesData(ELineType lineType, int saleId, string salesmanName) : base(lineType)
        {
            SaleId = saleId;
            SalesmanName = salesmanName;

            salesItemList = new List<SalesItemData>();
        }

        public int SaleId { get; private set; }
        public string SalesmanName { get; private set; }
        public ICollection<SalesItemData> SalesItemList { get => salesItemList; }

        public void AddItens(SalesItemData item)
        {
            if (!salesItemList.Contains(item))
                salesItemList.Add(item);
        }

    }
}