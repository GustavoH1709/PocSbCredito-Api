using MediatR;
using PocSbCredito.Domain.Contracts.FundoFIDC.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.FundoFIDC.Requests
{
    public class GetFundoFIDCRequest : IRequest<ObjectResponse<List<GetFundoFIDCResult>>>
    {
    }
}
