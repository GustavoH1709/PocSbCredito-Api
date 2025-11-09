using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Shared.Models.Recebivel;

namespace PocSbCredito.Application.Interfaces
{
    public interface IAtualizaRecebivelService
    {
        Task<AtualizacaoRecebivel_DTO?> HandleAsync(List<TB_Recebivel> recebiveis, decimal taxaMensal, CancellationToken ct);
    }
}
