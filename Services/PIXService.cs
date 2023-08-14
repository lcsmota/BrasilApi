using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Response;
using BrasilAPI.Services.Interfaces;
using Mapster;

namespace BrasilAPI.Services;

public class PIXService : IPIXService
{
    private readonly IBrasilApiPIX _brasilApiPIX;

    public PIXService(IBrasilApiPIX brasilApiPIX)
    {
        _brasilApiPIX = brasilApiPIX;
    }

    public async Task<GenericResponse<IEnumerable<PIXDTO>>> GetBanksUsePIXAsync()
    {
        var banks = await _brasilApiPIX.GetBanksUsePIXAsync();

        return banks.Adapt<GenericResponse<IEnumerable<PIXDTO>>>();
    }
}
