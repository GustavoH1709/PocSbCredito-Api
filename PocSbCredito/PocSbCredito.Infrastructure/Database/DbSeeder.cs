using PocSbCredito.Infrastructure.Database.Entities;
using PocSbCredito.Shared.Structs;

namespace PocSbCredito.Infrastructure.Database
{
    public class DbSeeder(AppDbContext db) : IDbSeeder
    {
        public void Seed()
        {
            if (!db.TB_Empresa.Any() && !db.TB_FundoFIDC.Any() && !db.TB_Recebivel.Any())
            {
                TB_Empresa empresa = new()
                {
                    Cnpj = "19568604000167",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Nome = "Empresa de Teste",
                    ValorLimiteCredito = 300000,
                    StRegistro = StatusRegistro.Ativo,
                    Email = "teste@teste.com"
                };

                db.TB_Empresa.Add(empresa);

                TB_FundoFIDC fundo = new()
                {
                    Cnpj = "26745800000125",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Nome = "Fundo FIDC de Teste",
                    RentabilidadeMensal = 0.01m,
                    SaldoDisponivel = 200000m
                };

                db.TB_FundoFIDC.Add(fundo);

                decimal valorOrig = 10000m;
                int nDocumento = 9876;

                for (int i = 0; i < 10; i++)
                {
                    TB_OperacaoAntecipacao op = new()
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DataOperacao = DateTime.Today,
                        DiasMedios = 10,
                        FundoId = fundo.Id,
                        EmpresaId = empresa.Id,
                        StatusOperacao = StatusOperacao.Pendente,
                        ValorTotalOriginal = valorOrig + 5000,
                        ValorTotalAntecipado = 500,
                        TaxaMensal = 0.25m
                    };

                    db.TB_OperacaoAntecipacao.Add(op);

                    for (int j = 0; j < 10; j++)
                    {
                        TB_Recebivel recebivel = new()
                        {
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            DataEmissao = DateTime.Today.AddDays(-5),
                            DataVencimento = DateTime.Today.AddDays(5),
                            EmpresaId = empresa.Id,
                            NumeroDocumento = nDocumento.ToString(),
                            ValorOriginal = valorOrig,
                            StatusRecebivel = StatusRecebivel.Disponivel,
                            ValorAntecipado = null,
                            OperacaoAntecipacaoId = op.Id
                        };

                        db.TB_Recebivel.Add(recebivel);

                        nDocumento++;
                        valorOrig += 250;
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
