using System.Dynamic;
using System.Text.Json;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiAddress : IBrasilApiAddress
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string apiEndpoint = "api/cep/v1/";

    private GenericResponse<Address> _address = new();

    public BrasilApiAddress(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<Address>> GetAddressByCEPAsync(string cep)
    {
        var httpClient = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilAPI = await httpClient.GetAsync($"{apiEndpoint}{cep}");

        var contentResponse = await responseBrasilAPI.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<Address>(contentResponse);

        if (responseBrasilAPI.IsSuccessStatusCode)
        {
            _address.HttpStatusCode = responseBrasilAPI.StatusCode;
            _address.Data = dataResponse;
        }
        else
        {
            _address.HttpStatusCode = responseBrasilAPI.StatusCode;
            _address.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _address;
    }
}
