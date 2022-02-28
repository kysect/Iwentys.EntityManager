using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Iwentys.EntityManager.DataSeeding.Tests;

public class Tests
{
    [Test]
    public void IwentysEntityManagerDbContextSeeding_DoesNotThrowException()
    {
        var collection = new ServiceCollection(); 

        collection.AddDbContext<IwentysEntityManagerDbContext>(o
            => o.UseSqlite("Data Source=Iwentys.db;Cache=Shared;"));

        collection.AddScoped<IIwentysEntityManagerDbContext, IwentysEntityManagerDbContext>();
        collection.AddScoped<IDbContextSeeder, DatabaseContextGenerator>();

        var context = collection.BuildServiceProvider().GetRequiredService<IwentysEntityManagerDbContext>();

        Assert.DoesNotThrow(() =>
        {
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted(); 
        });
    }
}