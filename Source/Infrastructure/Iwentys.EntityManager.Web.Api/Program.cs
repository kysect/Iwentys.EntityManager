using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.DataSeeding;
using Iwentys.EntityManager.Web.Configuration;
using Iwentys.EntityManager.Web.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddEntityManagerControllers()
    .SerializeEnumsAsStrings();

builder.Services.AddScoped<DatabaseContextGenerator>();
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

var provider = builder.Services.BuildServiceProvider();
var generator = provider.GetRequiredService<DatabaseContextGenerator>();
using (var context = provider.GetRequiredService<IwentysEntityManagerDbContext>()) {
    generator.Seed(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
