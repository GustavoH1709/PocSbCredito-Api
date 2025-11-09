using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocSbCredito.Infrastructure.Database.Entities
{
    [Table("tb_operacaoantecipacao")]
    public class TB_OperacaoAntecipacao : BaseEntity
    {
        [Required]
        [Column("empresa_id")]
        public Guid EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public TB_Empresa EmpresaFK { get; set; } = null!;

        public Guid FundoId { get; set; }

        [ForeignKey("FundoId")]
        public TB_FundoFIDC FundoFK { get; set; } = null!;

        [Required]
        [Column("data_operacao")]
        public DateTime DataOperacao { get; set; }

        [Required]
        [Column("taxa_mensal")]
        public decimal TaxaMensal { get; set; }

        [Required]
        [Column("valor_total_original")]
        public decimal ValorTotalOriginal { get; set; }

        [Required]
        [Column("valor_total_antecipado")]
        public decimal ValorTotalAntecipado { get; set; }

        [Required]
        [Column("dias_medios")]
        public int DiasMedios { get; set; }

        [Required]
        [StringLength(1)]
        [Column("status_operacao")]
        public string StatusOperacao { get; set; } = string.Empty;
    }
}
