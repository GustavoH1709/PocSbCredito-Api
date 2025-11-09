using Microsoft.EntityFrameworkCore;
using PocSbCredito.Infrastructure.Database;
using PocSbCredito.Infrastructure.Database.Entities;
using System.Linq.Expressions;

namespace PocSbCredito.Infrastructure.Repository;

public class BaseRepository(AppDbContext db) : IBaseRepository
{
    public async Task<TEntity?> AddAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        await db.AddAsync(entity, ct);

        int changed = await db.SaveChangesAsync(ct);
        if (changed == 0)
            return null;

        return entity;
    }

    public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct) where TEntity : BaseEntity
    {
        TEntity? first = await db.Set<TEntity>().FirstOrDefaultAsync(predicate, ct);
        return first;
    }

    public async Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity
    {
        entity.UpdatedAt = DateTime.UtcNow;

        db.Update(entity);

        int changed = await db.SaveChangesAsync(ct);
        return changed > 0;
    }
    public async Task<bool> DeleteAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity
    {
        db.Remove(entity);

        int changed = await db.SaveChangesAsync(ct);
        return changed > 0;
    }

    public async Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct) where TEntity : BaseEntity
    {
        List<TEntity> first = await db.Set<TEntity>().Where(predicate).ToListAsync(ct);
        return first;
    }
}
