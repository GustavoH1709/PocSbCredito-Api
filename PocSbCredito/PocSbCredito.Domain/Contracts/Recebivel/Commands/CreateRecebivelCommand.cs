using MediatR;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Recebivel.Commands;

public record CreateRecebivelCommand : IRequest<ObjectResponse<bool>>
{
    public Guid EmpresaId { get; set; }
    public string? Pagador { get; set; } = "N/A";
    public string? NumeroDocumento { get; set; }
    public decimal ValorOriginal { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal? ValorAntecipado { get; set; }
    public Guid OperacaoAntecipacaoId { get; set; }
}
