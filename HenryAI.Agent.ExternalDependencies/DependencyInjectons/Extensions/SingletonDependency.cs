using System.Reflection;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HenryAI.Agent.ExternalDependencies.DependencyInjectons.Extensions;

public static partial class DependencyInjections
{
    public static void RegisterSingletonDependencies(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromApplicationDependencies(a =>
                a.GetName().Name!.StartsWith("HenryAI.", StringComparison.OrdinalIgnoreCase))
            
            .AddClasses(c => c.AssignableTo<ISingletonDependency>())
            .As(t => t.GetInterfaces().Where(i => i != typeof(ISingletonDependency)))
            .WithSingletonLifetime()
        );

    }
}