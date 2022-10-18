using Blazor.FurnitoreStore.Repositories;
using Blazor.FurnitoreStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FurnitoreStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Blazor.FurnitoreStore.Shared.Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }
    }
}
