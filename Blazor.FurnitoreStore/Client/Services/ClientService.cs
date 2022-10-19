using Blazor.FurnitoreStore.Shared;
using System.Net.Http.Json;

namespace Blazor.FurnitoreStore.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Blazor.FurnitoreStore.Shared.Client>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Blazor.FurnitoreStore.Shared.Client>>($"api/client");
        }
    }
}
