
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Services;

public class BaseServiceFactory : IBaseServiceFactory, ISingletonDependency
{
    private readonly IReadOnlyDictionary<ActionType, IBaseService> _map;

    public BaseServiceFactory(IEnumerable<IBaseService> actions)
    {
        _map = actions.ToDictionary(action => action.Action);
    }
    
    public IBaseService Get(ActionType type) =>
        _map.TryGetValue(type, out var baseService)
            ? baseService
            : throw new KeyNotFoundException($"No provider for {type}");
 
}