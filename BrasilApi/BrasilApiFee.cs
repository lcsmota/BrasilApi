using System.Dynamic;
using System.Text.Json;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiFee : IBrasilApiFee
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string apiEndpoint = "/api/taxas/v1/";

    private GenericResponse<IEnumerable<Fee>> _fees = new();
    private GenericResponse<Fee> _fee = new();

    public BrasilApiFee(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<IEnumerable<Fee>>> GetAllFeesAsync()
    {
        var httpClientFactory = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilApi = await httpClientFactory.GetAsync(apiEndpoint);

        var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<IEnumerable<Fee>>(contentResponse);

        if (responseBrasilApi.IsSuccessStatusCode)
        {
            _fees.HttpStatusCode = responseBrasilApi.StatusCode;
            _fees.Data = dataResponse;
        }
        else
        {
            _fees.HttpStatusCode = responseBrasilApi.StatusCode;
            _fees.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _fees;
    }

    public async Task<GenericResponse<Fee>> GetFeeAsync(string sigla)
    {
        var httpClientFactory = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilApi = await httpClientFactory.GetAsync($"{apiEndpoint}{sigla}");

        var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<Fee>(contentResponse);

        if (responseBrasilApi.IsSuccessStatusCode)
        {
            _fee.HttpStatusCode = responseBrasilApi.StatusCode;
            _fee.Data = dataResponse;
        }
        else
        {
            _fee.HttpStatusCode = responseBrasilApi.StatusCode;
            _fee.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _fee;
    }
}
