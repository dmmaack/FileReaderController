using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;
using Flunt.Notifications;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToClient : Notifiable, IConvertToObject<Client>
    {
        public Client ExecuteConversion(string obj)
        {
            string[] data = obj.Split("\u00E7");

            var client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0]),
                                    cNPJ: data[1], 
                                    name: data[2], 
                                    businessArea: data[3]);
            
            AddNotifications(client);

            return client;            
        }
    }
}