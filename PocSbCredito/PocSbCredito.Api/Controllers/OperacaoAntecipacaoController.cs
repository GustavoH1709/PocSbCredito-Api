using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocSbCredito.Domain.Contracts.OperacaoAntecipacao.Commands;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacaoAntecipacaoController(IMediator mediator) : ControllerBase
    {
        [HttpPost("antecipar")]
        public Task<ObjectResponse<bool>> Antecipar([FromBody] AnteciparCommand command) => mediator.Send(command);
    }
}
