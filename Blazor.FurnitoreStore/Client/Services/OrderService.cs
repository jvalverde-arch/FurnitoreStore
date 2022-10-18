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
