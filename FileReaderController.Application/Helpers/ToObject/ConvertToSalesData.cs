using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using System.Linq;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToSalesData : IConvertToObject<SalesData>
    {
        public SalesData ExecuteConversion(string obj)
        {
            string[] data = obj.Split(new char['ç']);
            var itensList = data[2]
                                .Replace("[", string.Empty)
                                .Replace("]", string.Empty)
                                .Split(new char[',']).ToList();

            var sales = new SalesData(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0]),
                                      saleId: int.Parse(data[1]), salesmanName: data[5],
                                      message: string.Empty, hasError: false);
            
            itensList.ForEach(delegate(string item){
                var itemArray = item.Split(new char['-']);

                var saleItens = new SalesItemData(itemId: int.Parse(itemArray[0]), 
                                                  itemQuantity: int.Parse(itemArray[1]), 
                                                  itemPrice: decimal.Parse(itemArray[2]));

                sales.AddItens(saleItens);
            });

            return sales;   
        }
    }
}