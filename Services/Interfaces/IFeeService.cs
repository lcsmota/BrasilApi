using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces
{
    public interface IFeeService
    {
        Task<GenericResponse<IEnumerable<FeeDTO>>> GetAllFeesAsync();
        Task<GenericResponse<FeeDTO>> GetFeeAsync(string sigla);
    }
}