using Blazor.FurnitoreStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Repositories
{
    public interface IProductCategoryRepository
    {
        Task< IEnumerable<ProductCategory>> GetAll();

    }
}
