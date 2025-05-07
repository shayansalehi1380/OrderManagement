using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public IOrderRepository Orders { get; }

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
            Orders = new OrderRepository(_connection);
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            ((OrderRepository)Orders).SetTransaction(_transaction);
        }

        public async Task CommitAsync()
        {
            _transaction?.Commit();
            await Task.CompletedTask;
        }

        public async Task RollbackAsync()
        {
            _transaction?.Rollback();
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }

}
