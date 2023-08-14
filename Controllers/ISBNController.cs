using System.Diagnostics.Contracts;
using System.Net;
using BrasilAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ISBNController : ControllerBase
{
    private readonly IISBNService _isbnService;

    public ISBNController(IISBNService isbnService)
    {
        _isbnService = isbnService;
    }

    [HttpGet("{isbn}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(string isbn)
    {
        var book = await _isbnService.GetBookByISBNAsync(isbn);

        return book.HttpStatusCode == HttpStatusCode.OK
            ? Ok(book.Data)
            : StatusCode((int)book.HttpStatusCode, book.Error);
    }
}
