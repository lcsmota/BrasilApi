using System.Net;
using BrasilAPI.DTOs;
using BrasilAPI.Services.Interfaces;
using BrasilAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace BrasilAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{cep}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string cep)
    {
        var address = await _addressService.GetAddressByCEPAsync(cep);

        return address.HttpStatusCode == HttpStatusCode.OK
            ? Ok(address.Data)
            : StatusCode((int)address.HttpStatusCode, address.Error);
    }
}
