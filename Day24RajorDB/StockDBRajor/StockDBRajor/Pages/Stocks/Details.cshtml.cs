using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StockDBRajor.Models;

namespace StockDBRajor.Pages.Stocks
{
    public class DetailsModel : PageModel
    {
        private readonly StockDBRajor.Models.StockDbContext _context;

        public DetailsModel(StockDBRajor.Models.StockDbContext context)
        {
            _context = context;
        }

        public Stock Stock { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks.FirstOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                Stock = stock;
            }
            return Page();
        }
    }
}
