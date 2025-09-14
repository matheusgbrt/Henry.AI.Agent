using Agent.Refactoring.Domain.Templates.Dtos;
using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Services;

public interface ITemplateService
{
    public TemplateDto BuildTemplate(TemplateType templateType, Dictionary<ReplaceProperty, string> replaceProperties);
}