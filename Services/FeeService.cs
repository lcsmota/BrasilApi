using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Response;
using BrasilAPI.Services.Interfaces;
using Mapster;

namespace BrasilAPI.Services;

public class FeeService : IFeeService
{
    private readonly IBrasilApiFee _brasilApiFee;

    public FeeService(IBrasilApiFee brasilApiFee)
    {
        _brasilApiFee = brasilApiFee;
    }

    public async Task<GenericResponse<IEnumerable<FeeDTO>>> GetAllFeesAsync()
    {
        var fees = await _brasilApiFee.GetAllFeesAsync();

        return fees.Adapt<GenericResponse<IEnumerable<FeeDTO>>>();
    }

    public async Task<GenericResponse<FeeDTO>> GetFeeAsync(string sigla)
    {
        var fee = await _brasilApiFee.GetFeeAsync(sigla);

        return fee.Adapt<GenericResponse<FeeDTO>>();
    }
}
