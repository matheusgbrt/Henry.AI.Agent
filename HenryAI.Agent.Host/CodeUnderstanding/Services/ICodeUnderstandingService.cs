using HenryAI.Agent.Host.CodeUnderstanding.Dtos;

namespace HenryAI.Agent.Host.CodeUnderstanding.Services;

public interface ICodeUnderstandingService
{
    Task<CodeUnderstandingRawCodeOutputDto> UnderstandRawCode(string code);
}