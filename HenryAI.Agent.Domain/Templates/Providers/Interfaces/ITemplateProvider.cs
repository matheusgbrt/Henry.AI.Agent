using HenryAI.Agent.Domain.Templates.Tokens;

namespace HenryAI.Agent.Domain.Templates.Providers.Interfaces;

public interface ITemplateProvider
{
    TemplateType Type { get; }
    public string ProvideTemplate();
}