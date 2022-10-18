using Blazor.FurnitoreStore.Repositories;
using Blazor.FurnitoreStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FurnitoreStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order==null)
            {
                return BadRequest();
            }
            if (order.OrderNumber == 0)
                ModelState.AddModelError("OrderNumber", "Order Number can't be empty");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _orderRepository.InsertOrder(order);

            return NoContent();
        }

    }
}
