using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiPIX
{
    Task<GenericResponse<IEnumerable<PIX>>> GetBanksUsePIXAsync();
}
