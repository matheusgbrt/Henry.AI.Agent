using Agent.Refactoring.Domain.Templates.Dtos;
using Agent.Refactoring.Domain.Templates.Providers;
using Agent.Refactoring.Domain.Templates.Providers.Interfaces;
using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Services;

internal class TemplateService :ITemplateService
{
    private readonly ITemplateProviderFactory _templateProviderFactory;

    public TemplateService(ITemplateProviderFactory templateProviderFactory)
    {
        _templateProviderFactory = templateProviderFactory;
    }

    public TemplateDto BuildTemplate(TemplateType templateType,Dictionary<ReplaceProperty,string> replaceProperties)
    {
        var provider = _templateProviderFactory.Get(templateType);
        var raw = provider.ProvideTemplate();
        var replacedTemplate = raw;
        return new TemplateDto(templateType,raw,replacedTemplate);
    }
}