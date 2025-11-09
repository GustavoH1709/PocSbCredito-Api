using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocSbCredito.Infrastructure.Database.Entities;

[Table("tb_empresa")]
public class TB_Empresa : BaseEntity
{
    [Column("nome")]
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Column("cnpj")]
    [Required]
    public string Cnpj { get; set; } = string.Empty;

    [Column("email")]
    [Required]
    public string Email { get; set; } = string.Empty;

    [Column("valor_limite_credito")]
    public decimal? ValorLimiteCredito { get; set; } = null;

    [Column("st_registro")]
    [StringLength(1)]
    [Required]
    public string StRegistro { get; set; } = string.Empty;
}
