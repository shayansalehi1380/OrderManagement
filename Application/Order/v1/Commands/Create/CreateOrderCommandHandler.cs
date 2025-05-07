using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entity;

namespace Application.Order.v1.Commands.Create
{
    public class CreateOrderCommandHandler(IOrderRepository _orderRepository) : IRequestHandler<CreateOrderCommand, Unit>
    {

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entity.Order
            {
                CustomerName = request.CustomerName,
                OrderDate = DateTime.UtcNow,
                TotalAmount = request.TotalAmount
            };

            await _orderRepository.CreateOrderAsync(order);
            return Unit.Value;
        }
    }
}