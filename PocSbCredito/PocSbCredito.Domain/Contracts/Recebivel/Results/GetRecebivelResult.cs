namespace PocSbCredito.Domain.Contracts.Recebivel.Results
{
    public class GetRecebivelResult
    {
        public Guid RecebivelId { get; set; }
        public string StatusRecebivel { get; set; }
        public string? NumeroDocumento { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
