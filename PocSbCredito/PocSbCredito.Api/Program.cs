using Microsoft.EntityFrameworkCore;
using PocSbCredito.Application;
using PocSbCredito.Domain;
using PocSbCredito.Infrastructure;
using PocSbCredito.Infrastructure.Database;

namespace PocSbCredito.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddInfrastructure();
        builder.Services.AddDomain();
        builder.Services.AddApplication();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null; // Desativa a conversão camelCase
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        using (IServiceScope scope = app.Services.CreateScope())
        {
            AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate(); // Aplica as migrations pendentes
        }

        app.UseCors("AllowAll");
        app.MapControllers();

        app.Run();
    }
}
