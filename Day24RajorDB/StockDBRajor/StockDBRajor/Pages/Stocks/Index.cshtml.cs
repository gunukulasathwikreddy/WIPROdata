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
    public class IndexModel : PageModel
    {
        private readonly StockDBRajor.Models.StockDbContext _context;

        public IndexModel(StockDBRajor.Models.StockDbContext context)
        {
            _context = context;
        }

        public IList<Stock> Stock { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Stock = await _context.Stocks.ToListAsync();
        }
    }
}
