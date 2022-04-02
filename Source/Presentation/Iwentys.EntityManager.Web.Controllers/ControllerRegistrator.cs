using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.EntityManager.Web.Controllers;

public static class ControllerDependencyInjector
{
    public static IMvcBuilder AddEntityManagerControllers(this IMvcBuilder builder)
    {
        return builder.AddApplicationPart(typeof(ControllerDependencyInjector).Assembly);
    }
}