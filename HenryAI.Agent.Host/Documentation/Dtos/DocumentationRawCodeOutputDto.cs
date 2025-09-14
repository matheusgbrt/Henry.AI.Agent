namespace HenryAI.Agent.Host.Documentation.Dtos;

public record DocumentationRawCodeOutputDto(string DocumentedCode)
{
    public string DocumentedCode { get; set; } = DocumentedCode;
}