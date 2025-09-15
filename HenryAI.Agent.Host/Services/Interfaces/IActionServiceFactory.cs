using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Services.Interfaces;

public interface IActionServiceFactory
{
    IActionService Get(ActionType type);
}