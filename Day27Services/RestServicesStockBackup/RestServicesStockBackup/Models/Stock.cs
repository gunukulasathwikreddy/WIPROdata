using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServicesStockBackup.Models
{
    public class Stock
    {
        [Key]
        [Column("StockID")]
        public int StockID { get; set; }
        [Column("StockName")]
        public string? StockName { get; set; }
        [Column("Quantity")]
        public int? Quantity { get; set; }
        [Column("price")]
        public decimal? price { get; set; }
    }
}
