using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Application.Helpers.ToObject
{
    public class ConvertToSalesman : IConvertToObject<Salesman>
    {
        public Salesman ExecuteConversion(string obj)
        {
            string[] data = obj.Split(new char['ç']);

            var salesMan = new Salesman(lineType: (ELineType)EnumeratorHelper.GetValueFromDescription<ELineType>(data[0].ToString().ToString()),
                                        cPF: data[1].ToString(), 
                                        name: data[2].ToString(), 
                                        salary: decimal.Parse(data[3]));

            return salesMan;
        }
    }
}