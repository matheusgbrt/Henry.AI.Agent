using HenryAI.Agent.Domain.Templates.Providers.Interfaces;
using HenryAI.Agent.Domain.Templates.Tokens;
using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Interfaces;

namespace HenryAI.Agent.Domain.Templates.Providers;

public class RefactoringTemplateProvider : ITemplateProvider, ITransientDependency
{
    public TemplateType Type => TemplateType.RefactoringTemplate;

    public string ProvideTemplate()
    {
        return "Insert documentation template here //[{}]//";
    }
}