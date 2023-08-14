using System.Dynamic;
using System.Text.Json;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiPIX : IBrasilApiPIX
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string apiEndpoint = "/api/pix/v1/participants";

    private GenericResponse<IEnumerable<PIX>> _pix = new();

    public BrasilApiPIX(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<IEnumerable<PIX>>> GetBanksUsePIXAsync()
    {
        var httpClientFactory = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilApi = await httpClientFactory.GetAsync(apiEndpoint);

        var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<IEnumerable<PIX>>(contentResponse);

        if (responseBrasilApi.IsSuccessStatusCode)
        {
            _pix.HttpStatusCode = responseBrasilApi.StatusCode;
            _pix.Data = dataResponse;
        }
        else
        {
            _pix.HttpStatusCode = responseBrasilApi.StatusCode;
            _pix.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _pix;
    }
}
