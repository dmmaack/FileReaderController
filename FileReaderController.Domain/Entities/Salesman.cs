using FileReaderController.Domain.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Domain.Entities
{
    public class Salesman : EntitieBase
    {
        public Salesman(ELineType lineType, string name, string cPF, decimal salary, 
                        string message, bool hasError) : base(lineType, message, hasError)
        {
            Name = name;
            CPF = cPF;
            Salary = salary;
        }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public decimal Salary { get; private set; }
    }
}