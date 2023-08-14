using System.Net;
using BrasilAPI.Pagination;
using BrasilAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PIXController : ControllerBase
{
    private readonly IPIXService _pixService;

    public PIXController(IPIXService pixService)
    {
        _pixService = pixService;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
    {
        var banks = await _pixService.GetBanksUsePIXAsync();

        return banks.HttpStatusCode == HttpStatusCode.OK
            ? Ok(banks.Data
                    .Skip((parameters.PageNumber - 1) * parameters.QuantityOfItems)
                    .Take(parameters.QuantityOfItems)
                )
            : StatusCode((int)banks.HttpStatusCode, banks.Error);
    }
}
