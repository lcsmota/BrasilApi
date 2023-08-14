using System.Net;
using BrasilAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeeController : ControllerBase
{
    private readonly IFeeService _feeService;

    public FeeController(IFeeService feeService)
    {
        _feeService = feeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var fees = await _feeService.GetAllFeesAsync();

        return fees.HttpStatusCode == HttpStatusCode.OK
            ? Ok(fees.Data)
            : StatusCode((int)fees.HttpStatusCode, fees.Error);
    }

    [HttpGet("{sigla}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string sigla)
    {
        var fee = await _feeService.GetFeeAsync(sigla);

        return fee.HttpStatusCode == HttpStatusCode.OK
            ? Ok(fee.Data)
            : StatusCode((int)fee.HttpStatusCode, fee.Error);
    }
}
