﻿using Blazor.FurnitoreStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Repositories
{
    public  interface IOrderProductRepository
    {
        Task<bool> InsertOrderProduct(int orderId, Product product);
        Task<IEnumerable<Product>> GetByOrder(int orderId);
        Task<bool> DeleteOrderProductByOrder(int orderId);
    }
}
