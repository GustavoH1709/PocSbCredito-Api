using MediatR;
using PocSbCredito.Domain.Contracts.Empresa.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Empresa.Requests;

public record GetEmpresasRequest : IRequest<ObjectResponse<List<GetEmpresasResult>>>
{
    public string? Nome { get; set; }
    public string? Cnpj { get; set; }
    public string? Email { get; set; }
    public string? StRegistro { get; set; }
}
