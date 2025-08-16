using Microsoft.EntityFrameworkCore;

namespace RestStockCrud.Models
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

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
