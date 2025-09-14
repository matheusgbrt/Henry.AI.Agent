using System.ClientModel;
using OpenAI.Chat;

namespace HenryAI.Agent.Host.OpenAI.Services;

public class ChatService : IChatService
{
    private readonly ChatClient _chatClient;

    public ChatService(ChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> SendMessageAsync(string prompt)
    {
        ChatCompletion completion = await _chatClient.CompleteChatAsync(prompt);
        var result = completion.Content[0].Text;
        return result;
    }
}