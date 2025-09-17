using System.Text.Json.Serialization;

namespace HenryAI.Agent.Host.CodeUnderstanding.Dtos;

public class THeritage
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;
}