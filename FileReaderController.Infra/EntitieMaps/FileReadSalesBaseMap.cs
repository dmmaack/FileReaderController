using FileReaderController.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.EntitieMaps
{
    public class FileReadSalesBaseMap
    {
        public void ModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileReadSalesBase>(etd =>
            {
                etd.ToTable("FileReadSales");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(p => p.FileName).HasColumnName("FileName");
                etd.Property(p => p.ImportDate).HasColumnName("ImportDate");
                etd.Property(p => p.Message).HasColumnName("Message");
                etd.Property(p => p.HasError).HasColumnName("HasError");

                etd.HasMany(m => m.ClientList);
                etd.HasMany(m => m.SalesList);
                etd.HasMany(m => m.SalesmanList);
            });
        }
    }
}