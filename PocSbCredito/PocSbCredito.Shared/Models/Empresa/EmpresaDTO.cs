namespace PocSbCredito.Shared.Models.Empresa
{
    public class EmpresaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal? ValorLimiteCredito { get; set; } = null;
        public string StRegistro { get; set; } = string.Empty;
    }
}
