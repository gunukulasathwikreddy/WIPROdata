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
    public class DeleteModel : PageModel
    {
        private readonly StockDBRajor.Models.StockDbContext _context;

        public DeleteModel(StockDBRajor.Models.StockDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                Stock = stock;
                _context.Stocks.Remove(Stock);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
