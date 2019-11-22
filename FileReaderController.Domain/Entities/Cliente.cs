using FileReaderController.Shared.Enums;
using FileReaderController.Shared.Entities;

namespace FileReaderController.Domain.Entities
{
    public class Cliente : EntitieBase
    {
        public Cliente(int id, ELineType lineType, string cNPJ, string name, string businessArea) : base(id, lineType)
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