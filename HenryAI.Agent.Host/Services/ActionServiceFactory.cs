
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Services;

public class ActionServiceFactory : IActionServiceFactory, ISingletonDependency
{
    private readonly IReadOnlyDictionary<ActionType, IActionService> _map;

    public ActionServiceFactory(IEnumerable<IActionService> actions)
    {
        _map = actions.ToDictionary(action => action.Action);
    }
    
    public IActionService Get(ActionType type) =>
        _map.TryGetValue(type, out var baseService)
            ? baseService
            : throw new KeyNotFoundException($"No provider for {type}");
 
}