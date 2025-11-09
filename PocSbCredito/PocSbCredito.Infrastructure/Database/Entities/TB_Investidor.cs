using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocSbCredito.Infrastructure.Database.Entities
{
    [Table("tb_investidor")]
    public class TB_Investidor : BaseEntity
    {
        [Column("nome")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("saldo_aplicado")]
        [Required]
        public decimal SaldoAplicado { get; set; } = decimal.Zero;

        [Column("fundo_id")]
        [Required]
        public Guid FundoId { get; set; }

        [ForeignKey("FundoId")]
        public TB_FundoFIDC FundoFK { get; set; } = null!;
    }
}
