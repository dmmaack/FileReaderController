using FileReaderController.Shared.Entities;
using FileReaderController.Shared.Enums;

namespace FileReaderController.Domain.Entities
{
    public class Salesman : EntitieBase
    {
        public Salesman(int id, ELineType lineType, string name, string cPF, decimal salary) : base(id, lineType)
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