namespace PocSbCredito.Domain.Contracts.Empresa.Results;

public record GetEmpresasResult(
    string Nome,
    string Cnpj,
    string Email,
    decimal? ValorLimiteCredito,
    string StRegistro
);
