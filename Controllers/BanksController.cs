using System.Net;
using BrasilAPI.Pagination;
using BrasilAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BanksController : ControllerBase
{
    private readonly IBankService _bankService;

    public BanksController(IBankService bankService)
    {
        _bankService = bankService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] PaginationParameters parameters)
    {
        var banks = await _bankService.GetBanksAsync();

        return banks.HttpStatusCode == HttpStatusCode.OK
            ? Ok(banks.Data
                    .Skip((parameters.PageNumber - 1) * parameters.QuantityOfItems)
                    .Take(parameters.QuantityOfItems)
                )
            : StatusCode((int)banks.HttpStatusCode, banks.Error);
    }

    [HttpGet("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(short code)
    {
        var bank = await _bankService.GetBankByCodeAsync(code);

        return bank.HttpStatusCode == HttpStatusCode.OK
            ? Ok(bank.Data)
            : StatusCode((int)bank.HttpStatusCode, bank.Error);
    }
}
