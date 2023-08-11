using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces;

public interface IDDDService
{
    Task<GenericResponse<DDDDTO>> GetDDDAsync(short ddd);
}
