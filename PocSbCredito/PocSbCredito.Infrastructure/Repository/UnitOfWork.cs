using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PocSbCredito.Infrastructure.Database;
using System.Data;

namespace PocSbCredito.Infrastructure.Repository;

public class UnitOfWork(AppDbContext context, IBaseRepository baseRepository) : IUnitOfWork
{
    public IBaseRepository Repository { get; } = baseRepository;

    private IDbTransaction? transaction;

    public IDbTransaction BeginTransaction()
    {
        if (context.Database.GetDbConnection().State != ConnectionState.Open)
        {
            context.Database.OpenConnection();
        }

        transaction = context.Database.BeginTransaction().GetDbTransaction();
        return transaction;
    }

    public async Task<Exception?> SaveChangesAsync(CancellationToken ct)
    {
        try
        {
            await context.SaveChangesAsync(ct);
            transaction?.Commit();
            return null;
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            return ex;
        }
    }

    public void Rollback()
    {
        transaction?.Rollback();
    }

    public void Dispose()
    {
        transaction?.Dispose();
        context?.Dispose();
    }
}
