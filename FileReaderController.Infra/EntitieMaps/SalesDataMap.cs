using FileReaderController.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.EntitieMaps
{
    public class SalesDataMap
    {
        public void ModelCreating(ModelBuilder builder){
            builder.Entity<SalesData>(etd => {
                etd.ToTable("Sales");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(p => p.SaleId).HasColumnName("SaleId");
                etd.Property(p => p.SalesmanName).HasColumnName("SalesmanName"); 
                etd.Property(p => p.Message).HasColumnName("Message");
                etd.Property(p => p.HasError).HasColumnName("HasError");

                etd.HasMany(m => m.SalesItemList);
            });
        }
    }
}