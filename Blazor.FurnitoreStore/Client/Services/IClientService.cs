using Blazor.FurnitoreStore.Shared;

namespace Blazor.FurnitoreStore.Client.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Blazor.FurnitoreStore.Shared.Client>> GetAll();
    }
}
