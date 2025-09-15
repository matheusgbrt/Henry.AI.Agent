using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Services.Interfaces;

public interface IBaseServiceFactory
{
    IBaseService Get(ActionType type);
}