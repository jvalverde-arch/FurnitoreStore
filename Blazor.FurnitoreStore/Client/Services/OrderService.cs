using Blazor.FurnitoreStore.Shared;
using System.Net.Http.Json;

namespace Blazor.FurnitoreStore.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
           return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>($"api/order/");
        }

        public async Task<int> GetNextNumber()
        {
           return  await _httpClient.GetFromJsonAsync<int>($"api/order/getnextnumber");
        }

        public async Task SaveOrder(Order order)
        {
            if (order.Id == 0)
                await _httpClient.PostAsJsonAsync<Order>($"api/order/", order);
            else
                await _httpClient.PutAsJsonAsync<Order>($"api/order/{order.Id}", order);
        }
        public async Task<Order> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");
        }

        public async Task DeleteOrder(int id)
        {
            await _httpClient.DeleteAsync($"api/order/{id}");
        }
    }
}
