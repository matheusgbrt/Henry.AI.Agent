using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Providers.Interfaces;

internal interface ITemplateProviderFactory
{
    ITemplateProvider Get(TemplateType type);
    
}