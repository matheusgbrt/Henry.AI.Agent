using Agent.Refactoring.Domain.Templates.Providers.Interfaces;
using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Providers;

internal class DocumentationTemplateProvider : ITemplateProvider
{
    public TemplateType Type => TemplateType.DocumentationTemplate;

    public string ProvideTemplate()
    {
        return "Insert documentation template here //[{}]//";
    }
}