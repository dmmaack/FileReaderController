using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using Flunt.Notifications;
using System.Linq;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToSalesData : Notifiable, IConvertToObject<SalesData>
    {
        public SalesData ExecuteConversion(string obj)
        {
            string[] data = obj.Split("\u00E7");
            var itensList = data[2]
                                .Replace("[", string.Empty)
                                .Replace("]", string.Empty)
                                .Split(new char[',']).ToList();

            var sales = new SalesData(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0]),
                                      saleId: data[1], salesmanName: data[5]);
            
            itensList.ForEach(delegate(string item){
                var itemArray = item.Split(new char['-']);

                var saleItens = new SalesItemData(itemId: int.Parse(itemArray[0]), 
                                                  itemQuantity: int.Parse(itemArray[1]), 
                                                  itemPrice: decimal.Parse(itemArray[2]));

                sales.AddItens(saleItens);
            });

            AddNotifications(sales);

            return sales;   
        }
    }
}