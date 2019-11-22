using FileReaderController.Shared.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Domain.Entities
{
    public class SalesData : EntitieBase
    {
        public SalesData(int id, ELineType lineType, int saleId, int itemId, int itemQuantity, decimal itemPrice, string salesmanName) : base(id, lineType)
        {
            SaleId = saleId;
            ItemId = itemId;
            ItemQuantity = itemQuantity;
            ItemPrice = itemPrice;
            SalesmanName = salesmanName;
        }

        public int SaleId { get; private set; }
        public int ItemId { get; private set; }
        public int ItemQuantity { get; private set; }
        public decimal ItemPrice { get; private set; }
        public string SalesmanName { get; private set; }

    }
}