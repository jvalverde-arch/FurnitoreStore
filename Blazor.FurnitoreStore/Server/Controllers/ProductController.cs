using Blazor.FurnitoreStore.Repositories;
using Blazor.FurnitoreStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FurnitoreStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetByCategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _productRepository.GetByCategory(productCategoryId);
        }
    }
}
