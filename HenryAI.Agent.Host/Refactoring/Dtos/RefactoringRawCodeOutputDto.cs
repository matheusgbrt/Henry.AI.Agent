namespace HenryAI.Agent.Host.Documentation.Dtos;

public record RefactoringRawCodeOutputDto(string Code)
{
    public string Code { get; set; } = Code;
}