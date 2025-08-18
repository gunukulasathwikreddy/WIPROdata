using Microsoft.EntityFrameworkCore;

namespace StockDBRajor.Models
{
    public class StockDbContext : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-8JNDTKD;Database=wiprojuly;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}