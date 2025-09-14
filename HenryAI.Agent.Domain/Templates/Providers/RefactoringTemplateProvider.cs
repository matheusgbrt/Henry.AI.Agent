using Agent.Refactoring.Domain.Templates.Providers.Interfaces;
using Agent.Refactoring.Domain.Templates.Tokens;

namespace Agent.Refactoring.Domain.Templates.Providers;

internal class RefactoringTemplateProvider : ITemplateProvider
{
    public TemplateType Type => TemplateType.RefactoringTemplate;

    public string ProvideTemplate()
    {
        return "Insert documentation template here //[{}]//";
    }
}