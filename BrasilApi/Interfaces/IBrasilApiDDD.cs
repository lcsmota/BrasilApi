using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiDDD
{
    Task<GenericResponse<DDD>> GetDDDAsync(short ddd);
}
