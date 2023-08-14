using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiISBN : IBrasilApiISBN
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string apiEndpoint = "/api/isbn/v1/";

    private GenericResponse<ISBN> _isbn = new();

    public BrasilApiISBN(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<ISBN>> GetBookByISBNAsync(string isbn)
    {
        var httpClientFactory = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilApi = await httpClientFactory.GetAsync($"{apiEndpoint}{isbn}");

        var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<ISBN>(contentResponse);

        if (responseBrasilApi.IsSuccessStatusCode)
        {
            _isbn.HttpStatusCode = responseBrasilApi.StatusCode;
            _isbn.Data = dataResponse;
        }
        else
        {
            _isbn.HttpStatusCode = responseBrasilApi.StatusCode;
            _isbn.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _isbn;
    }
}
