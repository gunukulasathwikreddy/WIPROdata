using RestServicesStockBackup.Models;

namespace RestServicesStockBackup.Services
{
    public interface IAPiService
    {
        Task<IEnumerable<Stock>> GetStockAsync();
        Task<Stock?> GetStockByIdAsync(int id);
        Task<string> CreateStockAsync(Stock stock);
    }
}
