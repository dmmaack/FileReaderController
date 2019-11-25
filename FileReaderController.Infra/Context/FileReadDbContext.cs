using FileReaderController.Domain.Entities;
using FileReaderController.Infra.EntitieMaps;
using Microsoft.EntityFrameworkCore;

namespace FileReaderController.Infra.Context
{
    public class FileReadDbContext : DbContext
    {
        public FileReadDbContext(DbContextOptions<FileReadDbContext> options)
            : base(options) { }

        public DbSet<Client> BoardGames { get; set; }
        public DbSet<FileReadSalesBase> FileReadySales { get; set; }
        public DbSet<SalesData> Sales { get; set; }
        public DbSet<SalesItemData> SalesItem { get; set; }
        public Salesman Salesman { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasDefaultSchema("FileController");

            new ClientMap().ModelCreating(modelBuilder);
            new FileReadSalesBaseMap().ModelCreating(modelBuilder);
            new SalesDataMap().ModelCreating(modelBuilder);
            new SalesItemDataMap().ModelCreating(modelBuilder);
            new SalesmanMap().ModelCreating(modelBuilder);

        }
    }
}