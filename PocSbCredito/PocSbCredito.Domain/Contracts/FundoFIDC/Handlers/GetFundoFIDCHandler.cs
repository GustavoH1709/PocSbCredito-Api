using MediatR;
using Microsoft.EntityFrameworkCore;
using PocSbCredito.Domain.Contracts.FundoFIDC.Requests;
using PocSbCredito.Domain.Contracts.FundoFIDC.Results;
using PocSbCredito.Infrastructure.Database;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.FundoFIDC.Handlers
{
    public class GetFundoFIDCHandler(AppDbContext db) : IRequestHandler<GetFundoFIDCRequest, ObjectResponse<List<GetFundoFIDCResult>>>
    {
        public async Task<ObjectResponse<List<GetFundoFIDCResult>>> Handle(GetFundoFIDCRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<List<GetFundoFIDCResult>> result = new();

            var query = await (from a in db.TB_FundoFIDC select new GetFundoFIDCResult(a.Id, a.Nome)).ToListAsync(cancellationToken);

            result.Value = query;

            return result;
        }
    }
}
