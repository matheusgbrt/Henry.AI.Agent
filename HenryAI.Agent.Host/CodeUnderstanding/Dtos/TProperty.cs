using System.Text.Json.Serialization;

namespace HenryAI.Agent.Host.CodeUnderstanding.Dtos;

public class TProperty
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("Accessibility")]
    public string Accessibility { get; set; } = string.Empty;

    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;
}