using PocSbCredito.Infrastructure.Database.Entities;
using System.Linq.Expressions;

namespace PocSbCredito.Infrastructure.Repository;

public interface IBaseRepository
{
    Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct) where TEntity : BaseEntity;
    Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct) where TEntity : BaseEntity;
    Task<TEntity?> AddAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity;
    Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity;
    Task<bool> DeleteAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : BaseEntity;
}
