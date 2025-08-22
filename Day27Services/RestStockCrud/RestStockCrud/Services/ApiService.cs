using RestStockCrud.Models;

namespace RestStockCrud.Services
{
    public class ApiService : IAPiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5223/api/");
        }

        public async Task<string> CreateStockAsync(Stock stock)
        {
            var response = await _httpClient.PostAsJsonAsync("Stock", stock);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<Stock>> GetStockAsync()
        {
            var response = await _httpClient.GetAsync("Stock");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Stock>>()
                   ?? Enumerable.Empty<Stock>();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Stock/{id}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<Stock>();
        }
    }
}
