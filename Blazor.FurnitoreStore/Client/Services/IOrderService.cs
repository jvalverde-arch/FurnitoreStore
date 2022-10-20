using Blazor.FurnitoreStore.Shared;

namespace Blazor.FurnitoreStore.Client.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
        Task<int> GetNextNumber();
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetDetails(int id);
        Task DeleteOrder(int id);
    }
}
