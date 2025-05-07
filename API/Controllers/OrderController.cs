using Application.Order.v1.Commands.Create;
using Application.Order.v1.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var redult = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(redult);
        }
    }
}
