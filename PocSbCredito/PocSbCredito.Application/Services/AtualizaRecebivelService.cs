using PocSbCredito.Application.Interfaces;
using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Infrastructure.Repository;
using PocSbCredito.Shared.Models.Recebivel;
using PocSbCredito.Shared.Structs;

namespace PocSbCredito.Application.Services
{
    public class AtualizaRecebivelService(IUnitOfWork unitOfWork) : IAtualizaRecebivelService
    {
        public async Task<AtualizacaoRecebivel_DTO?> HandleAsync(List<TB_Recebivel> recebiveis, decimal taxaMensal, CancellationToken ct)
        {
            decimal totalOriginal = 0;
            decimal totalAntecipado = 0;
            int somaDias = 0;

            // Percorre cada recebível para calcular valores e prazos
            foreach (var rec in recebiveis)
            {
                var dias = (rec.DataVencimento - DateTime.Today).Days;
                var fator = taxaMensal * (dias / 30m);
                var valorLiquido = rec.ValorOriginal * (1 - fator);

                totalOriginal += rec.ValorOriginal;
                totalAntecipado += valorLiquido;
                somaDias += dias;

                rec.StatusRecebivel = StatusRecebivel.Antecipado;
                rec.ValorAntecipado = valorLiquido;

                bool updated = await unitOfWork.Repository.UpdateAsync(rec, ct);
                if (!updated)
                    return null;
            }

            AtualizacaoRecebivel_DTO result = new(totalOriginal, totalAntecipado, somaDias);

            return result;
        }
    }
}
