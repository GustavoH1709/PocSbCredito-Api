using MediatR;
using PocSbCredito.Application.Interfaces.Queries.Empresa;
using PocSbCredito.Domain.Contracts.Empresa.Requests;
using PocSbCredito.Domain.Contracts.Empresa.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Empresa.Handlers
{
    public class GetEmpresasHandler(IGetEmpresasQuery empresaQuery) : IRequestHandler<GetEmpresasRequest, ObjectResponse<List<GetEmpresasResult>>>
    {
        public async Task<ObjectResponse<List<GetEmpresasResult>>> Handle(GetEmpresasRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<List<GetEmpresasResult>> result = new([]);

            var empresas = await empresaQuery.GetAsync(request.Nome, request.Cnpj, request.Email, request.StRegistro);
            var mappedEmpresas = empresas.Select(x => new GetEmpresasResult(x.Id, x.Nome, x.Cnpj, x.Email, x.ValorLimiteCredito, x.StRegistro)).ToList();

            result.Value = mappedEmpresas;

            return result;
        }
    }
}
