using System.Reflection;
using Iwentys.EntityManager.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Iwentys.EntityManager.DataSeeding.Tools;

public static class DatabaseContextSeederAssemblyScanner
{
    public static IReadOnlyCollection<IDbContextSeeder> GetInstances(IServiceCollection dependencies, params Type[] markers)
    {
        var collection = new ServiceCollection();

        foreach (var descriptor in dependencies)
        {
            collection.Add(descriptor);
        }

        var types = markers
            .SelectMany(m => m.Assembly.DefinedTypes)
            .Where(t => t is not { IsAbstract: true, IsInterface: true })
            .Where(t => t.GetCustomAttribute<IgnoreAssemblyScannerAttribute>() is null)
            .ToArray();

        foreach (var typeInfo in types)
        {
            collection.AddSingleton(typeInfo.AsType());
        }

        var provider = collection.BuildServiceProvider();
        return types.Select(t => (IDbContextSeeder)provider.GetRequiredService(t.AsType())).ToArray();
    }
}