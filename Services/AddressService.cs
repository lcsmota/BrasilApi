using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Services.Interfaces;
using BrasilAPI.Response;
using Mapster;

namespace BrasilAPI.Services;

public class AddressService : IAddressService
{
    private readonly IBrasilApiAddress _brasilApiAddress;

    public AddressService(IBrasilApiAddress brasilApiAddress)
    {
        _brasilApiAddress = brasilApiAddress;
    }

    public async Task<GenericResponse<AddressDTO>> GetAddressByCEPAsync(string cep)
    {
        var address = await _brasilApiAddress.GetAddressByCEPAsync(cep);

        return address.Adapt<GenericResponse<AddressDTO>>();
    }
}
