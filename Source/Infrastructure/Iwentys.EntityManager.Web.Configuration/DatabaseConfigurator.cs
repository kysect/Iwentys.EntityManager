using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.DataSeeding;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.EntityManager.Web.Configuration;

public static class DatabaseConfigurator
{
    public static void AddEntityManagerDatabaseContext(this IServiceCollection service)
    {
        service
            .AddDbContext<IwentysEntityManagerDbContext>(o => o
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("InMemoryIwentysEntityManager.db")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

        service.AddScoped<DbContext, IwentysEntityManagerDbContext>();
        service.AddScoped<IIwentysEntityManagerDbContext, IwentysEntityManagerDbContext>();
        service.AddScoped<IDbContextSeeder, DatabaseContextGenerator>();
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipeline<,>));
    }

    public static void RecreateEntityManagerDatabase(this WebApplication app)
    {
        using IServiceScope serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<IwentysEntityManagerDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}