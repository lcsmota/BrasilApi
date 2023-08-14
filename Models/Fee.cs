using System.Text.Json.Serialization;

namespace BrasilAPI.Models;

public class Fee
{
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("valor")]
    public double? Valor { get; set; }
}
