using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entity;

namespace Application.Order.v1.Commands.Create
{
    public class CreateOrderCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateOrderCommand, Unit>
    {
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var order = new Domain.Entity.Order
                {
                    CustomerName = request.CustomerName,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = request.TotalAmount
                };

                await _unitOfWork.Orders.CreateOrderAsync(order);

                await _unitOfWork.CommitAsync();

                return Unit.Value;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
