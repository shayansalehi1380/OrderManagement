using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.v1.Queries.GetAll
{
    public class GetAllOrdersQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Domain.Entity.Order>>
    {

        public async Task<IEnumerable<Domain.Entity.Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
    }
}
