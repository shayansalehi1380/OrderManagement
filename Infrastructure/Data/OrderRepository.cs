using Dapper;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrderRepository(IDbConnection _dbConnection) : IOrderRepository
    {

        public async Task CreateOrderAsync(Order order)
        {
            var sql = @"INSERT INTO Orders (CustomerName, OrderDate, TotalAmount) 
                        VALUES (@CustomerName, @OrderDate, @TotalAmount)";
            await _dbConnection.ExecuteAsync(sql, order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var sql = "SELECT * FROM Orders";
            return await _dbConnection.QueryAsync<Order>(sql);
        }
    }
}
