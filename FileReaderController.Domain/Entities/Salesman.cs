using FileReaderController.Shared.Enums;
using FileReaderController.Shared.Helpers;
using Flunt.Validations;

namespace FileReaderController.Domain.Entities
{
    public class Salesman : EntitieBase
    {
        public Salesman(){}

        public Salesman(ELineType lineType, string name, string cPF, decimal salary) : base(lineType)
        {
            Name = name;
            CPF = cPF;
            Salary = salary;

            AddNotifications(new Contract().Requires()
            .HasMinLen(name, 3, "Salesman.Name", "O Nome contem menos de 3 caracteres.")
            .IsTrue(DocumentValidation.Validate(cPF, EDocumentType.CPF), "Salesman.CPF", "Documento invalido"));

        }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public decimal Salary { get; private set; }
    }
}