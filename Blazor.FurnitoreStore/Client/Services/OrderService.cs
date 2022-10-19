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
            if (order.Id ==0)
            {
                await _httpClient.PostAsJsonAsync<Order>($"api/order/", order);
            }
            else
            {
                //invoke update
            }
                    
        }
    }
}
