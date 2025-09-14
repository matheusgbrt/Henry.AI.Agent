using Agent.Refactoring.Domain.Templates.Providers.Interfaces;
using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Providers;

internal class TemplateProviderFactory :ITemplateProviderFactory
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