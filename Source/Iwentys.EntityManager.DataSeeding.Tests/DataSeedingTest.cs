using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Iwentys.EntityManager.DataSeeding.Tests;

public class Tests
{
    private static readonly ServiceCollection Collection = new ();

    [SetUp]
    public void AddSeedingServices()
    {
        Collection.Clear();

        Collection.AddDbContext<IwentysEntityManagerDbContext>(o
            => o.UseSqlite("Data Source=Iwentys.db;Cache=Shared;"));

        Collection.AddScoped<IIwentysEntityManagerDbContext, IwentysEntityManagerDbContext>();
        Collection.AddScoped<IDbContextSeeder, DatabaseContextGenerator>();
    }

    [Test]
    public void IwentysEntityManagerDbContextSeeding_DoesNotThrowException()
    {
        var context = Collection.BuildServiceProvider().GetRequiredService<IwentysEntityManagerDbContext>();

        Assert.DoesNotThrow(() =>
        {
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted(); 
        });
    }
}