
using FileReaderController.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.EntitieMaps
{
    public class ClientMap
    {
        public void ModelCreating(ModelBuilder builder){
            builder.Entity<Client>(etd => {
                etd.ToTable("Client");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(p => p.CNPJ).HasColumnName("CNPJ");
                etd.Property(p => p.Name).HasColumnName("Name");                
                etd.Property(p => p.BusinessArea).HasColumnName("BusinessArea");
                etd.Property(p => p.Message).HasColumnName("Message");
                etd.Property(p => p.HasError).HasColumnName("HasError");
            });
        }
    }
}