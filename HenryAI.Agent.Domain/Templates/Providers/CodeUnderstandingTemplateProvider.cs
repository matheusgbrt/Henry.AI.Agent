using HenryAI.Agent.Domain.Templates.Providers.Interfaces;
using HenryAI.Agent.Domain.Templates.Tokens;

namespace HenryAI.Agent.Domain.Templates.Providers;

public class CodeUnderstandingTemplateProvider : ITemplateProvider
{
    public TemplateType Type => TemplateType.CodeUnderstandingTemplate;
    public string ProvideTemplate()
    {
        string baseJsonResponseTemplate = BaseJsonTemplate.ProvideTemplate();
        var template = baseJsonResponseTemplate += @"
Analise o código a seguir com os seguintes critérios:
1) Trate-o como um arquivo de classe em C#.
2) Entenda as propriedades existentes na classe e seus métodos.
3) Entenda as dependências que essa classe possui, suas heranças e implementações.
4) Não altere nada do código, seu propósito é apenas o entendimento e documentação do código no formato requisitado.

O JSON deve ter as seguintes propriedades:
Namespace: String do namespace onde a classe se encontra.
Dependencies: Um array de objetos do tipo TDependency das dependencias existentes da classe analisada.
Implementations: Um array de objetos do tipo TImplementation da classe analisada.
Constructors: Um array de objetos do tipo TConstructor da classe analisada.
Heritages: Um array de objetos do tipo THeritage da classe analisada.
Properties: Um array de objetos do tipo TProperty
Methods: Um array de objetos do tipo TMethod
Errors: Um array de objetos do tipo TError, preenchido apenas se houver um erro na análise.
OK: Uma flag booleana para sinalizar que a análise ocorreu como o esperado

Os tipos mencionados possuem as seguintes propriedades, em ordem:

TDependency:
1)Name: Nome da classe
2)Accessibility: Acessibilidade da dependencia, ex: public, private...

TImplementation:
1)Name: Nome da interface implementada

THeritage:
1)Name: Nome da classe herdada

TProperty:
1)Name: Nome da propriedade
2)Type: Tipo da propriedade
3)Accessibility: Acessibilidade da dependencia, ex: public, private...
4)Description: Sua descricão para esta propriedade

TMethod:
1)Name: Nome do método
2)Return: Tipo de retorno do método
3)Parameters: Array de objetos do tipo TParameter dos parametros do método analisado
4)Annotations: Array de objetos do tipo TAnnotation do método analisado
5)Description: Sua descrição para este método

TParameter:
1)Name: Nome do parametro
2)Type: Tipo do parametro
3)Description: Sua descrição do parametro
4)Default value: Caso possua default value, seu valor
5)Optional: Boolean para sinalizar se o parametro é opcional ou não

TAnnotation:
1)Name: Nome da annotation
2)Parameters: Array de objetos do tipo TParameter dos parâmetros da annotation.
3)Description: Sua descrição para esta annotation

TConstructor:
1)Parameters: Array de objetos do tipo TParameter dos parametros do método analisado
2)Description: Sua descrição para este construtor

TError:
1)Description: Uma curta descrição do motivo de a análise não poder ser concluída


Com isso dito, aqui está o código a ser analisado:

";
        return template;
    }
}