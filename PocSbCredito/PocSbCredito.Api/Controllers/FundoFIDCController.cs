using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocSbCredito.Domain.Contracts.FundoFIDC.Requests;
using PocSbCredito.Domain.Contracts.FundoFIDC.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Api.Controllers
{
    [Route("[controller]")]
    public class FundoFIDCController(IMediator mediator) : ControllerBase
    {
        [HttpGet("listarFundos")]
        public async Task<ObjectResponse<List<GetFundoFIDCResult>>> Get([FromQuery] GetFundoFIDCRequest request) => await mediator.Send(request);
    }
}
