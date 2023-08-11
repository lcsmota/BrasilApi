using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiAddress
{
    Task<GenericResponse<Address>> GetAddressByCEPAsync(string cep);
}
