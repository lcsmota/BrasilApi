using System.Text.Json.Serialization;

namespace BrasilAPI.Models;

public class PIX
{
    [JsonPropertyName("ispb")]
    public string? Ispb { get; set; }

    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("nome_reduzido")]
    public string? NomeReduzido { get; set; }

    [JsonPropertyName("modalidade_participacao")]
    public string? ModalidadeParticipacao { get; set; }

    [JsonPropertyName("tipo_participacao")]
    public string? TipoParticipacao { get; set; }

    [JsonPropertyName("inicio_operacao")]
    public DateTime? InicioOperacao { get; set; }
}
