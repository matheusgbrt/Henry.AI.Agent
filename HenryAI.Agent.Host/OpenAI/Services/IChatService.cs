namespace HenryAI.Agent.Host.OpenAI.Services;

public interface IChatService
{
    Task<string> SendMessageAsync(string prompt);
}