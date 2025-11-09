using Microsoft.Extensions.DependencyInjection;
using PocSbCredito.Application.Interfaces.Queries.Empresa;
using PocSbCredito.Infrastructure.Queries.Empresa;
using PocSbCredito.Infrastructure.Repository;

namespace PocSbCredito.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //queries
            services.AddScoped<IGetEmpresasQuery, GetEmpresasQuery>();
        }
    }
}
