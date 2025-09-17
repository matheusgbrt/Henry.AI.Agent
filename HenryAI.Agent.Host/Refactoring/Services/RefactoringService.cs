using HenryAI.Agent.Domain.Templates.Services;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;
using HenryAI.Agent.Host.OpenAI.Services;

namespace HenryAI.Agent.Host.Refactoring.Services;

public class RefactoringService :IRefactoringService, ITransientDependency
{
    private TemplateType TemplateType => TemplateType.RefactoringTemplate;
    private readonly ITemplateService _templateService;
    private readonly IChatService _chatService;

    public RefactoringService(ITemplateService templateService, IChatService chatService)
    {
        _templateService = templateService;
        _chatService = chatService;
    }

    public async Task<string> RefactorRawCode(string code)
    {
        var replaceProperties = new Dictionary<ReplaceProperty, string>()
        {
            {ReplaceProperty.Code,code}
        };
        var templateDto = _templateService.BuildTemplate(TemplateType,replaceProperties);
        if (!templateDto.Ok)
            return "";
        var response= await _chatService.SendMessageAsync(templateDto.ReplacedTemplate);
        return response;
    }
}