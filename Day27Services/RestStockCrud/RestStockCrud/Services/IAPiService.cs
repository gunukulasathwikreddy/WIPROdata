using RestStockCrud.Models;

namespace RestStockCrud.Services
{
    public interface IAPiService
    {
        Task<IEnumerable<Stock>> GetStockAsync();
        Task<Stock?> GetStockByIdAsync(int id);
        Task<string> CreateStockAsync(Stock stock);
    }
}
