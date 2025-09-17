using System.Text.Json.Serialization;

namespace HenryAI.Agent.Host.CodeUnderstanding.Dtos;

public class TAnnotation
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Parameters")]
    public List<TParameter> Parameters { get; set; } = new();

    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;
}