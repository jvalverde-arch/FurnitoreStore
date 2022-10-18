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
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var sql = @"Select Id, FirstName, LastName, BirthDate, Phone, Address
                        From Clients";

            return await _dbConnection.QueryAsync<Client>(sql, new { });
        }
    }
}
