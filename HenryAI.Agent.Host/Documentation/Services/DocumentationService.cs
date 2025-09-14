using HenryAI.Agent.Domain.Templates.Services;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.OpenAI.Services;

namespace HenryAI.Agent.Host.Documentation.Services;

public class DocumentationService : IDocumentationService, ITransientDependency
{
    private readonly TemplateType _templateType = TemplateType.DocumentationTemplate;
    private readonly ITemplateService _templateService;
    private readonly IChatService _chatService;

    public DocumentationService(ITemplateService templateService, IChatService chatService)
    {
        _templateService = templateService;
        _chatService = chatService;
    }

    public async Task<string> CreateDocumentation(string code)
    {
        var replaceProperties = new Dictionary<ReplaceProperty, string>();
        replaceProperties.Add(ReplaceProperty.Code,code);
        var templateDto = _templateService.BuildTemplate(_templateType,replaceProperties);
        if (!templateDto.Ok)
        {
            return "";
        }

        var response = await _chatService.SendMessageAsync(templateDto.ReplacedTemplate);
        return response;
    }
}