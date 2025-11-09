using MediatR;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.OperacaoAntecipacao.Commands
{
    public record AnteciparCommand : IRequest<ObjectResponse<bool>>
    {
        public Guid EmpresaId { get; set; }
        public Guid FundoId { get; set; }
        public decimal TaxaMensal { get; set; }
        public List<Guid> Recebiveis { get; set; } = [];
    }
}
