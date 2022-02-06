using System.Text.Json.Serialization;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.DataSeeding;
using Iwentys.EntityManager.WebApi;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IwentysEntityManagerDatabaseContext>(o => o
    .UseLazyLoadingProxies()
    .UseInMemoryDatabase("InMemoryIwentysEntityManager.db")
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipeline<,>));
builder.Services.AddScoped<DbContext, IwentysEntityManagerDatabaseContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDbContextSeeder, DatabaseContextGenerator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (IServiceScope serviceScope = app.Services.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IwentysEntityManagerDatabaseContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
