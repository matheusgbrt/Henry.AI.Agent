using HenryAI.Agent.Domain.Templates.Providers.Interfaces;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;

namespace HenryAI.Agent.Domain.Templates.Providers;

public class TemplateProviderFactory :ITemplateProviderFactory, ISingletonDependency
{
    private readonly IReadOnlyDictionary<TemplateType, ITemplateProvider> _map;

    public TemplateProviderFactory(IEnumerable<ITemplateProvider> providers)
    {
        _map = providers.ToDictionary(p => p.Type);
    }

    public ITemplateProvider Get(TemplateType type) =>
        _map.TryGetValue(type, out var provider)
            ? provider
            : throw new KeyNotFoundException($"No provider for {type}");
}