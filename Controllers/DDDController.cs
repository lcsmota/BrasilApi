using System.Net;
using BrasilAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DDDController : ControllerBase
{
    private readonly IDDDService _dddService;

    public DDDController(IDDDService dddService)
    {
        _dddService = dddService;
    }

    [HttpGet("{ddd}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(short ddd)
    {
        var result = await _dddService.GetDDDAsync(ddd);

        return result.HttpStatusCode == HttpStatusCode.OK
            ? Ok(result.Data)
            : StatusCode((int)result.HttpStatusCode, result.Error);
    }
}
