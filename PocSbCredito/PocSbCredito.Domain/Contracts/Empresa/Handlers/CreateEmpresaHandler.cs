using MediatR;
using PocSbCredito.Domain.Contracts.Empresa.Commands;
using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Infrastructure.Repository;
using PocSbCredito.Shared.Models;
using PocSbCredito.Shared.Structs;

namespace PocSbCredito.Domain.Contracts.Empresa.Handlers
{
    public class CreateEmpresaHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateEmpresaCommand, ObjectResponse<bool>>
    {
        public async Task<ObjectResponse<bool>> Handle(CreateEmpresaCommand command, CancellationToken cancellationToken)
        {
            ObjectResponse<bool> result = new(false);

            using var t = unitOfWork.BeginTransaction();


            TB_Empresa tb_empresa = new()
            {
                Email = command.Email,
                StRegistro = StatusRegistro.Ativo,
                ValorLimiteCredito = command.ValorLimiteCredito,
                Nome = command.Nome,
                Cnpj = command.Cnpj
            };

            TB_Empresa? saved = await unitOfWork.Repository.AddAsync(tb_empresa, cancellationToken);

            if (saved is not null)
            {
                result.Value = true;
                t.Commit();
            }

            return result;
        }
    }
}
