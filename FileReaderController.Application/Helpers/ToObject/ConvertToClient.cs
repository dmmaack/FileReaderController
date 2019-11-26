using System;
using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToClient : IConvertToObject<Client>
    {
        public Client ExecuteConversion(string obj)
        {
            string[] data = obj.Split(new char['ç']);

            var client = new Client(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0].ToString().ToString()),
                                    cNPJ: data[1].ToString(), 
                                    name: data[2].ToString(), 
                                    businessArea: data[3].ToString());

            return client;            
        }
    }
}