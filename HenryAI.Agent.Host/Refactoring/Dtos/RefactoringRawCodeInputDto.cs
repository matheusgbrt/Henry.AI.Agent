namespace HenryAI.Agent.Host.Documentation.Dtos;

public record RefactoringRawCodeInputDto(string Code)
{
    public string Code { get; set; } = Code;
}