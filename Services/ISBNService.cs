using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Response;
using BrasilAPI.Services.Interfaces;
using Mapster;

namespace BrasilAPI.Services;

public class ISBNService : IISBNService
{
    private readonly IBrasilApiISBN _brasilApiISBN;

    public ISBNService(IBrasilApiISBN brasilApiISBN)
    {
        _brasilApiISBN = brasilApiISBN;
    }

    public async Task<GenericResponse<ISBNDTO>> GetBookByISBNAsync(string isbn)
    {
        var book = await _brasilApiISBN.GetBookByISBNAsync(isbn);

        return book.Adapt<GenericResponse<ISBNDTO>>();
    }
}
