﻿using Blazor.FurnitoreStore.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {

        private readonly IDbConnection _dbConnection;

        public OrderProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertOrderProduct(int orderId, Product product)
        {
            var sql = @"INSERT INTO dbo.OrderProducts
                                                   (OrderId
                                                   ,ProductId
                                                   ,Quantity)
                                             VALUES
                                                   (@OrderId
                                                   ,@ProductId
                                                   ,@Quantity)
                        
                       ";

            var result = await _dbConnection.ExecuteAsync(sql, new
            {
                OrderId = orderId,
                ProductId=product.Id,
                Quantity = product.Quantity

            });

            return result > 0;
        }
    }
}
