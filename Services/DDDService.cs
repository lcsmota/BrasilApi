using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Response;
using BrasilAPI.Services.Interfaces;
using Mapster;

namespace BrasilAPI.Services;

public class DDDService : IDDDService
{
    private readonly IBrasilApiDDD _brasilApiDDD;

    public DDDService(IBrasilApiDDD brasilApiDDD)
    {
        _brasilApiDDD = brasilApiDDD;
    }

    public async Task<GenericResponse<DDDDTO>> GetDDDAsync(short ddd)
    {
        var result = await _brasilApiDDD.GetDDDAsync(ddd);

        return result.Adapt<GenericResponse<DDDDTO>>();
    }
}
