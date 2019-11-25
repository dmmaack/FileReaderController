using FileReaderController.Shared.Enums;
using FileReaderController.Domain.Entities;

namespace FileReaderController.Domain.Entities
{
    public class Client : EntitieBase
    {
        public Client(ELineType lineType, string cNPJ, string name, string businessArea, 
                      string message, bool hasError) : base(lineType, message, hasError)
        {
            CNPJ = cNPJ;
            Name = name;
            BusinessArea = businessArea;
        }

        public string CNPJ { get; private set; }
        public string Name { get; private set; }
        public string BusinessArea { get; private set; }

        


    }
}