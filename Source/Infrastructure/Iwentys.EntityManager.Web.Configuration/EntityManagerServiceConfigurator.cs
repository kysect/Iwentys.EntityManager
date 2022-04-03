using System.Text.Json.Serialization;
using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.MappingConfiguration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.EntityManager.Web.Configuration;

public static class EntityManagerServiceConfigurator
{
    public static IMvcBuilder SerializeEnumsAsStrings(this IMvcBuilder builder)
    {
        return builder.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }

    public static IServiceCollection InjectEntityManagerLibraries(this IServiceCollection service)
    {
        service.AddMediatR(typeof(GetSubjectTeachers).Assembly);
        service.AddAutoMapper(typeof(EntityManagerMappingProfile).Assembly);
        return service;
    }
}