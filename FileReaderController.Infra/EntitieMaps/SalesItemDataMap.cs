using FileReaderController.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.EntitieMaps
{
    public class SalesItemDataMap
    {
         public void ModelCreating(ModelBuilder builder){
            builder.Entity<SalesItemData>(etd => {
                etd.ToTable("SalesItem");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(p => p.ItemId).HasColumnName("ItemId");
                etd.Property(p => p.ItemQuantity).HasColumnName("ItemQuantity");                
                etd.Property(p => p.ItemPrice).HasColumnName("ItemPrice");
            });
        }
    }
}