using Blazor.FurnitoreStore.Shared;

namespace Blazor.FurnitoreStore.Client.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);

    }
}
