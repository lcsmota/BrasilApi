using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces;

public interface IAddressService
{
    Task<GenericResponse<AddressDTO>> GetAddressByCEPAsync(string cep);
}
