using MediatR;
using PocSbCredito.Domain.Contracts.Recebivel.Commands;
using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Infrastructure.Repository;
using PocSbCredito.Shared.Models;
using PocSbCredito.Shared.Structs;

namespace PocSbCredito.Domain.Contracts.Recebivel.Handlers
{
    public class CreateRecebivelHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRecebivelCommand, ObjectResponse<bool>>
    {
        public async Task<ObjectResponse<bool>> Handle(CreateRecebivelCommand request, CancellationToken cancellationToken)
        {
            ObjectResponse<bool> result = new(false);

            using var t = unitOfWork.BeginTransaction();

            TB_Recebivel tb_recebivel = new()
            {
                DataEmissao = request.DataEmissao,
                EmpresaId = request.EmpresaId,
                DataVencimento = request.DataVencimento,
                Pagador = request.Pagador ?? "N/A",
                StatusRecebivel = StatusRecebivel.Disponivel,
                ValorAntecipado = request.ValorAntecipado,
                ValorOriginal = request.ValorOriginal,
                NumeroDocumento = request.NumeroDocumento,
                OperacaoAntecipacaoId = request.OperacaoAntecipacaoId
            };

            TB_Recebivel? saved = await unitOfWork.Repository.AddAsync(tb_recebivel, cancellationToken);
            if (saved is not null)
            {
                result.Value = true;
                t.Commit();
            }

            return result;
        }
    }
}
