using Blazor.FurnitoreStore.Repositories;
using Blazor.FurnitoreStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Blazor.FurnitoreStore.Server.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IOrderProductRepository _orderProductRepository;

        public OrderController(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
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

            // await _orderRepository.InsertOrder(order);

            //TRANSACCIÓN
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                order.Id = await _orderRepository.GetNextId();

                await _orderRepository.InsertOrder(order);

                if(order.Products!=null && order.Products.Any())
                { 
                    foreach (var prd in order.Products)
                    {
                        //Insertar OrderProduct
                        await _orderProductRepository.InsertOrderProduct(order.Id,prd);
                    }
                }
                scope.Complete();
            }

               

            return NoContent();
        }

        [HttpGet("getnextnumber")]
        public async Task<int> GetNextNumber()
        {
            return  await _orderRepository.GetNextNumber();
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.GetAll();
        }

    }
}
