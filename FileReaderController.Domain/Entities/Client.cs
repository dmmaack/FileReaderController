using FileReaderController.Shared.Enums;
using FileReaderController.Domain.Entities;
using Flunt.Validations;
using FileReaderController.Shared.Helpers;

namespace FileReaderController.Domain.Entities
{
    public class Client : EntitieBase
    {
        public Client(ELineType lineType, string cNPJ, string name, string businessArea) : base(lineType)
        {
            CNPJ = cNPJ;
            Name = name;
            BusinessArea = businessArea;            

            AddNotifications(new Contract().Requires()
            .HasMinLen(name, 3, "Client.Name", "O Nome contem menos de 3 caracteres.")
            .IsTrue(DocumentValidation.Validate(cNPJ, EDocumentType.CNPJ), "Client.CNPJ", "Documento invalido")
            .IsNullOrEmpty(businessArea, "Client.BusinessArea","Informacao nao definida"));
        }

        public string CNPJ { get; private set; }
        public string Name { get; private set; }
        public string BusinessArea { get; private set; }
    }
}