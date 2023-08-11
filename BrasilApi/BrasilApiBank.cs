using System.Dynamic;
using System.Text.Json;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi;

public class BrasilApiBank : IBrasilApiBank
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string apiEndpoint = "/api/banks/v1/";

    private GenericResponse<Bank> _bank = new();
    private GenericResponse<IEnumerable<Bank>> _banks = new();

    public BrasilApiBank(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GenericResponse<IEnumerable<Bank>>> GetBanksAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilApi = await httpClient.GetAsync(apiEndpoint);

        var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<IEnumerable<Bank>>(contentResponse);

        if (responseBrasilApi.IsSuccessStatusCode)
        {
            _banks.HttpStatusCode = responseBrasilApi.StatusCode;
            _banks.Data = dataResponse;
        }
        else
        {
            _banks.HttpStatusCode = responseBrasilApi.StatusCode;
            _banks.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _banks;
    }

    public async Task<GenericResponse<Bank>> GetBankByCodeAsync(short code)
    {
        var httpClient = _httpClientFactory.CreateClient("BrasilAPI");

        using var responseBrasilAPI = await httpClient.GetAsync($"{apiEndpoint}{code}");

        var contentResponse = await responseBrasilAPI.Content.ReadAsStringAsync();

        var dataResponse = JsonSerializer.Deserialize<Bank>(contentResponse);

        if (responseBrasilAPI.IsSuccessStatusCode)
        {
            _bank.HttpStatusCode = responseBrasilAPI.StatusCode;
            _bank.Data = dataResponse;
        }
        else
        {
            _bank.HttpStatusCode = responseBrasilAPI.StatusCode;
            _bank.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
        }

        return _bank;
    }
}
