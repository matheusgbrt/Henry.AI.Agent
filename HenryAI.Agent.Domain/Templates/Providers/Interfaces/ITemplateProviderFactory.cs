using HenryAI.Agent.Domain.Templates.Tokens;

namespace HenryAI.Agent.Domain.Templates.Providers.Interfaces;

public interface ITemplateProviderFactory
{
    ITemplateProvider Get(TemplateType type);
    
}