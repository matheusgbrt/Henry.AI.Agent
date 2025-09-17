using System.Text.Json.Serialization;

namespace HenryAI.Agent.Host.CodeUnderstanding.Dtos;

public class TError
{
    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;
}