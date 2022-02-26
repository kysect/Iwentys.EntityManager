using System.Text.Json.Serialization;
using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.Web.Configuration;
using Iwentys.EntityManager.Web.Controllers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddEntityManagerControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityManagerDatabaseContext();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipeline<,>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.RecreateEntityManagerDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
