using MediatR;
using PocSbCredito.Domain.Contracts.Recebivel.Results;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Recebivel.Requests
{
    public class GetRecebivelRequest : IRequest<ObjectResponse<List<GetRecebivelResult>>>
    {
        public Guid? EmpresaId { get; set; }
        public Guid? FundoId { get; set; }
        public string? StatusRecebivel { get; set; }
    }
}
