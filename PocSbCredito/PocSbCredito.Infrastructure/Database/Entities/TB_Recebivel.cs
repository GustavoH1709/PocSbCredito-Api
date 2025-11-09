using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocSbCredito.Infrastructure.Database.Entities
{
    [Table("tb_recebivel")]
    public class TB_Recebivel : BaseEntity
    {
        [Column("empresa_id")]
        [Required]
        public Guid EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public TB_Empresa EmpresaFK { get; set; } = null!;

        [Column("pagador")]
        public string Pagador { get; set; } = "N/A";

        [Column("numero_documento")]
        public string? NumeroDocumento { get; set; }

        [Column("valor_original")]
        [Required]
        public decimal ValorOriginal { get; set; }

        [Column("data_emissao")]
        [Required]
        public DateTime DataEmissao { get; set; }

        [Column("data_vencimento")]
        [Required]
        public DateTime DataVencimento { get; set; }

        [Column("valor_antecipado")]
        public decimal? ValorAntecipado { get; set; }

        [Column("operacao_antecipacao_id")]
        [Required]
        public Guid OperacaoAntecipacaoId { get; set; }

        [ForeignKey("OperacaoAntecipacaoId")]
        public TB_OperacaoAntecipacao OperacaoAntecipacaoFK { get; set; } = null!;

        [Column("status_recebivel")]
        [StringLength(1)]
        [Required]
        public string StatusRecebivel { get; set; } = string.Empty;
    }
}
