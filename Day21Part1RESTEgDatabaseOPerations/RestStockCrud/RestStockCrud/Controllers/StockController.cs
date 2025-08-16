using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestStockCrud.Models;

namespace RestStockCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockDbContext _context;

        public StockController(StockDbContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetResult(int id)
        {
            var stock = await _context.Stocks.Where(x => x.StockID == id).SingleOrDefaultAsync();
            if (stock == null)
            {
                return NotFound();
            }
            return stock;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return "Stock Inserted...";
        }
    }
}
