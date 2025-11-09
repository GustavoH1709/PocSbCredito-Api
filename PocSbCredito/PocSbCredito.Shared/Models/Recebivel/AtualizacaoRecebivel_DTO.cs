namespace PocSbCredito.Shared.Models.Recebivel
{
    public class AtualizacaoRecebivel_DTO(decimal totalOriginal, decimal totalAntecipado, int somaDias)
    {
        public decimal TotalOriginal = totalOriginal;
        public decimal TotalAntecipado = totalAntecipado;
        public int SomaDias = somaDias;
    }
}
