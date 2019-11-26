using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using Flunt.Notifications;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToSalesman : Notifiable, IConvertToObject<Salesman>
    {
        public Salesman ExecuteConversion(string obj)
        {
            string[] data = obj.Split("\u00E7");

            var salesMan = new Salesman(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0]),
                                        cPF: data[1], 
                                        name: data[2], 
                                        salary: decimal.Parse(data[3]));

            AddNotifications(salesMan);

            return salesMan;
        }
    }
}