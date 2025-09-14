using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Providers.Interfaces;

internal interface ITemplateProvider
{
    TemplateType Type { get; }
    public string ProvideTemplate();
}