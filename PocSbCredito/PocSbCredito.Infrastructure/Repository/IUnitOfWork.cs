using System.Data;

namespace PocSbCredito.Infrastructure.Repository;

public interface IUnitOfWork
{
    IBaseRepository Repository { get; }
    IDbTransaction BeginTransaction();
    Task<Exception?> SaveChangesAsync(CancellationToken ct);
    void Rollback();
}
