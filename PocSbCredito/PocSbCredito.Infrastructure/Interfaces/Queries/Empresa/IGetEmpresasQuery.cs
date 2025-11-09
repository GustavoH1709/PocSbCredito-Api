using PocSbCredito.Shared.Models.Empresa;

namespace PocSbCredito.Application.Interfaces.Queries.Empresa;

public interface IGetEmpresasQuery
{
    Task<List<EmpresaDTO>> GetAsync(string? Nome, string? Cnpj, string? Email, string? StRegistro);
}
