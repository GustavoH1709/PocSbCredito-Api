using MediatR;
using PocSbCredito.Shared.Models;

namespace PocSbCredito.Domain.Contracts.Empresa.Commands;

public record CreateEmpresaCommand(string Nome, string Cnpj, string Email, decimal? ValorLimiteCredito) : IRequest<ObjectResponse<bool>>;
