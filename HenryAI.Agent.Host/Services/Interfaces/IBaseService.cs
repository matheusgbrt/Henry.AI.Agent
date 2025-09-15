using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Services.Interfaces;

public interface IBaseService
{
    ActionType Action { get; }
    Task<string> BaseAction(string code);
}