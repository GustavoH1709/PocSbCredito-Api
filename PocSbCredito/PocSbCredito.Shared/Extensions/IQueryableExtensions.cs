using System.Linq.Expressions;

namespace PocSbCredito.Shared.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TResponse> Filter<TResponse>(this IQueryable<TResponse> query, bool shouldAddFilter, Expression<Func<TResponse, bool>> expression)
        {
            if (!shouldAddFilter)
                return query;

            return query.Where(expression);
        }
    }
}
