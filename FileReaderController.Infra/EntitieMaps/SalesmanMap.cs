using FileReaderController.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.EntitieMaps
{
    public class SalesmanMap
    {
        public void ModelCreating(ModelBuilder builder)
        {
            builder.Entity<Salesman>(etd =>
            {
                etd.ToTable("Salesman");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(p => p.Name).HasColumnName("Name");
                etd.Property(p => p.CPF).HasColumnName("CPF");
                etd.Property(p => p.Salary).HasColumnName("Salary");
                etd.Property(p => p.Message).HasColumnName("Message");
                etd.Property(p => p.HasError).HasColumnName("HasError");
            });
        }
    }
}