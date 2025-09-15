using HenryAI.Agent.Domain.Templates.Services;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.OpenAI.Services;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Refactoring.Services;

public class RefactoringService : IBaseService, ITransientDependency
{
    private TemplateType _templateType => TemplateType.RefactoringTemplate;
    public ActionType Action => ActionType.Refactoring;
    
    private readonly ITemplateService _templateService;
    private readonly IChatService _chatService;

    public RefactoringService(ITemplateService templateService, IChatService chatService)
    {
        _templateService = templateService;
        _chatService = chatService;
    }

    public async Task<string> BaseAction(string code)
    {
        var replaceProperties = new Dictionary<ReplaceProperty, string>()
        {
            {ReplaceProperty.Code,code}
        };
        var templateDto = _templateService.BuildTemplate(_templateType,replaceProperties);
        if (!templateDto.Ok)
            return "";
        var response= await _chatService.SendMessageAsync(templateDto.ReplacedTemplate);
        return response;
    }
}