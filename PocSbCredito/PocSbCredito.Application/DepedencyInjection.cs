using Microsoft.Extensions.DependencyInjection;
using PocSbCredito.Application.Interfaces;
using PocSbCredito.Application.Services;

namespace PocSbCredito.Application;

public static class DepedencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAtualizaRecebivelService, AtualizaRecebivelService>();
    }
}
