using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces;

public interface IPIXService
{
    Task<GenericResponse<IEnumerable<PIXDTO>>> GetBanksUsePIXAsync();
}
