using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.NUnit3;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.DataSeeding;
using Iwentys.EntityManager.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Iwentys.EntityManager.Web.Api.Tests;

public class Tests
{
    [Test]
    [AutoData]
    public async Task IwentysEntityManagerDbContextDeployment_DoesNotThrowException(
        string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<IwentysEntityManagerDbContext>(o => o
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=Iwentys.db;Cache=Shared;")
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipeline<,>));
        builder.Services.AddScoped<DbContext, IwentysEntityManagerDbContext>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IDbContextSeeder, DatabaseContextGenerator>();

        var app = builder.Build();

        using IServiceScope serviceScope = app.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<IwentysEntityManagerDbContext>();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        Assert.DoesNotThrowAsync(async () => await app.StartAsync(CancellationToken.None));
    }
}