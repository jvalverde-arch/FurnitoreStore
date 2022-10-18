using Blazor.FurnitoreStore.Shared;

namespace Blazor.FurnitoreStore.Client.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategotyId);
    }
}
