using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiISBN
{
    Task<GenericResponse<ISBN>> GetBookByISBNAsync(string isbn);
}
