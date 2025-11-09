using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocSbCredito.Domain.Contracts.Empresa.Commands;
using PocSbCredito.Domain.Contracts.Empresa.Requests;
using PocSbCredito.Domain.Contracts.Empresa.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ObjectResponse<List<GetEmpresasResult>>> Get([FromQuery] GetEmpresasRequest request) => await mediator.Send(request);

        [HttpPost]
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateEmpresaCommand command) => await mediator.Send(command);
    }
}
