using HenryAI.Agent.Domain.Templates.Services;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.OpenAI.Services;
using HenryAI.Agent.Host.Services.Interfaces;
using HenryAI.Agent.Host.Tokens;

namespace HenryAI.Agent.Host.Documentation.Services;

public class DocumentationService : IActionService, ITransientDependency
{
    private TemplateType TemplateType => TemplateType.DocumentationTemplate;
    public ActionType Action => ActionType.Documentation;

    private readonly ITemplateService _templateService;
    private readonly IChatService _chatService;

    public DocumentationService(ITemplateService templateService, IChatService chatService)
    {
        _templateService = templateService;
        _chatService = chatService;
    }
    
    public async Task<string> BaseAction(string code)
    {
        var replaceProperties = new Dictionary<ReplaceProperty, string>();
        replaceProperties.Add(ReplaceProperty.Code,code);
        var templateDto = _templateService.BuildTemplate(TemplateType,replaceProperties);
        if (!templateDto.Ok)
        {
            return "";
        }

        var response = await _chatService.SendMessageAsync(templateDto.ReplacedTemplate);
        return response;
    }
}