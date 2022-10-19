using Blazor.FurnitoreStore.Shared;
using System.Net.Http.Json;

namespace Blazor.FurnitoreStore.Client.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetByCategory(int productCategotyId)
        {
            // return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/product");
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/product/GetByCategory/{productCategotyId}");
        }

        public async Task<Product> GetDeails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
        }
    }
}
