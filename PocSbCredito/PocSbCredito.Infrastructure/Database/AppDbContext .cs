using Microsoft.EntityFrameworkCore;
using PocSbCredito.Infrastructure.Database.Entities;

namespace PocSbCredito.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TB_Empresa> TB_Empresa { get; set; }
    public DbSet<TB_FundoFIDC> TB_FundoFIDC { get; set; }
    public DbSet<TB_Investidor> TB_Investidor { get; set; }
    public DbSet<TB_OperacaoAntecipacao> TB_OperacaoAntecipacao { get; set; }
    public DbSet<TB_Recebivel> TB_Recebivel { get; set; }
}