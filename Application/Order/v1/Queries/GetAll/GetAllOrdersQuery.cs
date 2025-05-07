using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.v1.Queries.GetAll
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Domain.Entity.Order>>
    {

    }
}
