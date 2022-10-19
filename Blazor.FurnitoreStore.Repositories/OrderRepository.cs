using Blazor.FurnitoreStore.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var sql = @"select 
                        o.Id, OrderNumber, ClientId, OrderDate, DeliveryDate, Total,
                        c.LastName  + ', ' + c.FirstName as ClientName
                        From Orders o
	                        inner join Clients c ON o.ClientId = c.Id
                        ";

            return await _dbConnection.QueryAsync<Order>(sql, new { });
        }

        public async Task<int> GetNextId()
        {
            var sql = @"Select IDENT_CURRENT('Orders') +1";

            return await _dbConnection.QueryFirstAsync<int>(sql, new { });
        }

        public async  Task<int> GetNextNumber()
        {
            try
            {
                var sql = @"Select 
                              case 
	                            when max(OrderNumber) is null then 1
	                            else max(OrderNumber) + 1 
                              end
                            From Orders ";

                return await _dbConnection.QueryFirstAsync<int>(sql, new { });
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task<bool> InsertOrder(Order order)
        {
            var sql = @"Insert into Orders ( OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
                    Values  ( @OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)";

            var result = await _dbConnection.ExecuteAsync(sql,
                 new
                 {
                     order.OrderNumber,
                     order.ClientId,
                     order.OrderDate,
                     order.DeliveryDate,
                     order.Total

                 });

            return result > 0;

        }
    }
}
