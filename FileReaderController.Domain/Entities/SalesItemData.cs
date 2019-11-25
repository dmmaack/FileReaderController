using FileReaderController.Shared.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FileReaderController.Domain.Entities
{
    public class SalesItemData
    {
        public SalesItemData(int itemId, int itemQuantity, decimal itemPrice)
        {
            ItemId = itemId;
            ItemQuantity = itemQuantity;
            ItemPrice = itemPrice;
        }

        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public int ItemQuantity { get; private set; }
        public decimal ItemPrice { get; private set; }
    }
}