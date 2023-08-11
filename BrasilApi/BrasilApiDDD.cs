using System.Dynamic;
using System.Text.Json;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiDDD : IBrasilApiDDD
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string apiEndpoint = "/api/ddd/v1/";

    private GenericResponse<DDD> _ddd = new();

    public BrasilApiDDD(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<DDD>> GetDDDAsync(short ddd)
    {
        var httpClient = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilAPI = await httpClient.GetAsync($"{apiEndpoint}{ddd}");

        var contentResponse = await responseBrasilAPI.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<DDD>(contentResponse);

        if (responseBrasilAPI.IsSuccessStatusCode)
        {
            _ddd.HttpStatusCode = responseBrasilAPI.StatusCode;
            _ddd.Data = dataResponse;
        }
        else
        {
            _ddd.HttpStatusCode = responseBrasilAPI.StatusCode;
            _ddd.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _ddd;
    }
}
