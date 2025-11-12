namespace PocSbCredito.Domain.Contracts.Empresa.Results;

public record GetEmpresasResult(
    Guid EmpresaId,
    string Nome,
    string Cnpj,
    string Email,
    decimal? ValorLimiteCredito,
    string StRegistro
);
