using System.Text.Json.Serialization;

namespace BrasilAPI.Models;

public class DDD
{
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("cities")]
    public List<string>? Cities { get; set; }
}
