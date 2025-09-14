using HenryAI.Agent.Domain.Templates.Providers.Interfaces;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;

namespace HenryAI.Agent.Domain.Templates.Providers;

public class DocumentationTemplateProvider : ITemplateProvider, ITransientDependency
{
    public TemplateType Type => TemplateType.DocumentationTemplate;

    public string ProvideTemplate()
    {
        return "Repita a mensagem a seguir: //[Code]//";
    }
}