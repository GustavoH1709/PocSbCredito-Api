using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocSbCredito.Domain.Contracts.Recebivel.Commands;
using PocSbCredito.Domain.Contracts.Recebivel.Requests;
using PocSbCredito.Domain.Contracts.Recebivel.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecebivelController(IMediator mediator) : ControllerBase
    {
        [HttpGet("listarRecebiveis")]
        public async Task<ObjectResponse<List<GetRecebivelResult>>> Get([FromQuery] GetRecebivelRequest request) => await mediator.Send(request);

        [HttpPost]
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateRecebivelCommand command) => await mediator.Send(command);
    }
}
