using MediatR;
using PocSbCredito.Application.Interfaces;
using PocSbCredito.Domain.Contracts.OperacaoAntecipacao.Commands;
using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Infrastructure.Repository;
using PocSbCredito.Shared.Models;
using PocSbCredito.Shared.Models.Recebivel;
using PocSbCredito.Shared.Structs;

namespace PocSbCredito.Domain.Contracts.OperacaoAntecipacao.Handlers
{
    public class AnteciparHandler(IUnitOfWork unitOfWork, IAtualizaRecebivelService atualizaRecebivelService) : IRequestHandler<AnteciparCommand, ObjectResponse<bool>>
    {
        public async Task<ObjectResponse<bool>> Handle(AnteciparCommand command, CancellationToken cancellationToken)
        {
            ObjectResponse<bool> result = new(false);

            TB_Empresa? empresa = await unitOfWork.Repository.GetAsync<TB_Empresa>(item => item.Id == command.EmpresaId, cancellationToken);
            if (empresa is null)
            {
                //TODO - CRIAR NOTIFICACAO DE VALIDACAO
                return result;
            }

            List<TB_Recebivel> recebiveis = await unitOfWork.Repository.GetListAsync<TB_Recebivel>(item => command.Recebiveis.Contains(item.Id) && item.StatusRecebivel == StatusRecebivel.Disponivel, cancellationToken);

            using var t = unitOfWork.BeginTransaction();

            AtualizacaoRecebivel_DTO? att = await atualizaRecebivelService.HandleAsync(recebiveis, command.TaxaMensal, cancellationToken);
            if (att is null)
                return result;

            int diasMedios = att.SomaDias / recebiveis.Count;

            var pendentes = await unitOfWork.Repository.GetListAsync<TB_OperacaoAntecipacao>(o => o.EmpresaId == o.EmpresaId && o.StatusOperacao == StatusOperacao.Pendente, cancellationToken);
            decimal totalAntecipadoEmAberto = pendentes.Sum(item => item.ValorTotalAntecipado);

            var limiteRestante = empresa.ValorLimiteCredito - totalAntecipadoEmAberto;

            if (att.TotalAntecipado > limiteRestante)
            {
                //TODO - CRIAR NOTIFICACAO DE VALIDACAO
                return result;
            }

            TB_OperacaoAntecipacao tB_OperacaoAntecipacao = new()
            {
                Id = Guid.NewGuid(),
                EmpresaId = command.EmpresaId,
                FundoId = command.FundoId,
                DataOperacao = DateTime.Now,
                TaxaMensal = command.TaxaMensal,
                ValorTotalOriginal = att.TotalOriginal,
                ValorTotalAntecipado = att.TotalAntecipado,
                DiasMedios = diasMedios,
                StatusOperacao = StatusOperacao.Pendente
            };

            TB_OperacaoAntecipacao? op = await unitOfWork.Repository.AddAsync(tB_OperacaoAntecipacao, cancellationToken);
            if (op is not null)
            {
                result.Value = true;
                t.Commit();
            }

            return result;
        }
    }
}
