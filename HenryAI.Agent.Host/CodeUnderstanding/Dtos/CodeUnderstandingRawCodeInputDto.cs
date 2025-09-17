namespace HenryAI.Agent.Host.CodeUnderstanding.Dtos;

public record CodeUnderstandingRawCodeInputDto(string Code)
{
    public string Code { get; set; } = Code;
}