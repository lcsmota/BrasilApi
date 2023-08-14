using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces;

public interface IISBNService
{
    Task<GenericResponse<ISBNDTO>> GetBookByISBNAsync(string isbn);
}
