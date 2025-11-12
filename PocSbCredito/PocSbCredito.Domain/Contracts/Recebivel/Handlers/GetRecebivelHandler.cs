using MediatR;
using Microsoft.EntityFrameworkCore;
using PocSbCredito.Domain.Contracts.Recebivel.Requests;
using PocSbCredito.Domain.Contracts.Recebivel.Results;
using PocSbCredito.Infrastructure.Database;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Recebivel.Handlers
{
    public class GetRecebivelHandler(AppDbContext db) : IRequestHandler<GetRecebivelRequest, ObjectResponse<List<GetRecebivelResult>>>
    {
        public async Task<ObjectResponse<List<GetRecebivelResult>>> Handle(GetRecebivelRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<List<GetRecebivelResult>> result = new([]);

            var query = await (from a in db.TB_Recebivel
                               join b in db.TB_Empresa on a.EmpresaId equals b.Id
                               select new GetRecebivelResult()
                               {
                                   DataEmissao = a.DataEmissao.ToString("dd/MM/yyyy"),
                                   DataVencimento = a.DataVencimento.ToString("dd/MM/yyyy"),
                                   NumeroDocumento = a.NumeroDocumento,
                                   RecebivelId = a.Id,
                                   StatusRecebivel = a.StatusRecebivel,
                                   NomeEmpresa = b.Nome
                               }).ToListAsync(cancellationToken);

            result.Value = query;

            return result;
        }
    }
}
