using Blazor.FurnitoreStore.Shared;

namespace Blazor.FurnitoreStore.Client.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategories();
    }
}
