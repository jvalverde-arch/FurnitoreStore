using Blazor.FurnitoreStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Repositories
{
    public  interface IOrderRepository
    {
        Task<bool> InsertOrder(Order order);
        Task<int> GetNextNumber();
        Task<int> GetNextId();

        Task<IEnumerable<Order>> GetAll();



    }
}
