using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockDBRajor.Models
{
    public class Stock
    {
        [Key]
        [Column("StockID")]
        [Display(Name = "Stock ID")]
        public int StockID { get; set; }

        [Column("StockName")]
        [Display(Name = "Stock Name")]
        [Required(ErrorMessage = "Stock Name is required")]
        [StringLength(30, ErrorMessage = "Stock Name cannot exceed 30 characters")]
        public string? StockName { get; set; }

        [Column("Quantity")]
        [Required(ErrorMessage = "Quantity of the stock is required")]
        public int? Quantity { get; set; }

        [Column("price")]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price of the stock is required")]
        public decimal? price { get; set; }

    }
}