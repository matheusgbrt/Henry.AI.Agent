using HenryAI.Agent.Domain.Templates.Dtos;
using HenryAI.Agent.Domain.Templates.Tokens;

namespace HenryAI.Agent.Domain.Templates.Services;

public interface ITemplateService
{
    public TemplateDto BuildTemplate(TemplateType templateType, IReadOnlyDictionary<ReplaceProperty, string> replaceProperties);
}