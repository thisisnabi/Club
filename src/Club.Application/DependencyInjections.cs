using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Club.Application;

public static class DependencyInjections
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
    {
        var assembly = typeof(IAssemblyMaker).Assembly;

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(assembly);
        });

        return services;
    }

}
