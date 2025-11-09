using Microsoft.EntityFrameworkCore;
using PocSbCredito.Application.Interfaces.Queries.Empresa;
using PocSbCredito.Infrastructure.Database;
using PocSbCredito.Shared.Extensions;
using PocSbCredito.Shared.Models.Empresa;

namespace PocSbCredito.Infrastructure.Queries.Empresa;

public class GetEmpresasQuery(AppDbContext db) : IGetEmpresasQuery
{
    public async Task<List<EmpresaDTO>> GetAsync(string? Nome, string? Cnpj, string? Email, string? StRegistro)
    {
        var query = (from a in db.TB_Empresa
                     select new EmpresaDTO
                     {
                         Cnpj = a.Cnpj,
                         Email = a.Email,
                         StRegistro = a.StRegistro,
                         Id = a.Id,
                         Nome = a.Nome,
                         ValorLimiteCredito = a.ValorLimiteCredito,
                     })
                    .Filter(Nome.HasValue(), item => (item.Nome ?? "").Equals(Nome, StringComparison.CurrentCultureIgnoreCase))
                    .Filter(Cnpj.HasValue(), item => item.Cnpj == Cnpj)
                    .Filter(StRegistro.HasValue(), item => item.StRegistro == StRegistro);

        return await query.ToListAsync();
    }
}
