using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestStockCrud.Models;
using RestStockCrud.Services;

namespace RestStockCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APiServiceController : ControllerBase
    {
        private readonly IAPiService _apiService;

        public APiServiceController(IAPiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowStockAll()
        {
            var result = await _apiService.GetStockAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SearchStock(int id)
        {
            var result = await _apiService.GetStockByIdAsync(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            var result = await _apiService.CreateStockAsync(stock);
            return Ok(result);
        }
    }
}
