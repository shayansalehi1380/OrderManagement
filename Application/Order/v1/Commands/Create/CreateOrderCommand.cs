using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.v1.Commands.Create
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
