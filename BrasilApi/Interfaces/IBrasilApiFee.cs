using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiFee
{
    Task<GenericResponse<IEnumerable<Fee>>> GetAllFeesAsync();
    Task<GenericResponse<Fee>> GetFeeAsync(string sigla);
}
