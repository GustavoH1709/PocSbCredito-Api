using MediatR;
using Microsoft.EntityFrameworkCore;
using PocSbCredito.Domain.Contracts.Recebivel.Requests;
using PocSbCredito.Domain.Contracts.Recebivel.Results;
using PocSbCredito.Infrastructure.Database;
using PocSbCredito.Shared.Extensions;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Recebivel.Handlers
{
    public class GetRecebivelHandler(AppDbContext db) : IRequestHandler<GetRecebivelRequest, ObjectResponse<List<GetRecebivelResult>>>
    {
        public async Task<ObjectResponse<List<GetRecebivelResult>>> Handle(GetRecebivelRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<List<GetRecebivelResult>> result = new([]);

            var query = (from a in db.TB_Recebivel
                         join b in db.TB_Empresa on a.EmpresaId equals b.Id
                         select new
                         {
                             DataEmissao = a.DataEmissao.ToString("dd/MM/yyyy"),
                             DataVencimento = a.DataVencimento.ToString("dd/MM/yyyy"),
                             NumeroDocumento = a.NumeroDocumento,
                             RecebivelId = a.Id,
                             StatusRecebivel = a.StatusRecebivel,
                             NomeEmpresa = b.Nome,
                             EmpresaId = b.Id

                         })
                         .Filter(!string.IsNullOrWhiteSpace(request.StatusRecebivel), item => item.StatusRecebivel == request.StatusRecebivel)
                         .Filter(request.EmpresaId is not null && request.FundoId != Guid.Empty, item => item.EmpresaId == request.EmpresaId);

            result.Value = await query.Select(x => new GetRecebivelResult()
            {
                DataEmissao = x.DataEmissao,
                DataVencimento = x.DataVencimento,
                NumeroDocumento = x.NumeroDocumento,
                RecebivelId = x.RecebivelId,
                StatusRecebivel = x.StatusRecebivel,
                NomeEmpresa = x.NomeEmpresa
            }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
