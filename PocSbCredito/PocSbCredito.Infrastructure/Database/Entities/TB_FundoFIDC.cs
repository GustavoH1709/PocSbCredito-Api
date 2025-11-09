using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocSbCredito.Infrastructure.Database.Entities
{
    [Table("tb_fundofidc")]
    public class TB_FundoFIDC : BaseEntity
    {
        [Column("nome")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("cnpj")]
        [Required]
        public string Cnpj { get; set; } = string.Empty;

        [Column("saldo_disponivel")]
        [Required]
        public decimal SaldoDisponivel { get; set; } = decimal.Zero;

        [Column("rentabilidade_mensal")]
        [Required]
        public decimal RentabilidadeMensal { get; set; } = decimal.Zero;
    }
}
