using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocSbCredito.Domain.Contracts.Recebivel.Commands;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecebivelController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateRecebivelCommand command) => await mediator.Send(command);
    }
}
