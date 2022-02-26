using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.EntityManager.Web.Configuration;

public static class EntityManagerServiceConfigurator
{
    public static IMvcBuilder SerializeEnumsAsStrings(this IMvcBuilder builder)
    {
        return builder.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }
}