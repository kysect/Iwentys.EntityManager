using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.Web.Configuration;
using Iwentys.EntityManager.Web.Controllers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddEntityManagerControllers()
    .SerializeEnumsAsStrings();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityManagerDatabaseContext();
builder.Services.InjectEntityManagerLibraries();

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
