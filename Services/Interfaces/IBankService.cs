using BrasilAPI.DTOs;
using BrasilAPI.Response;

namespace BrasilAPI.Services.Interfaces;

public interface IBankService
{
    Task<GenericResponse<IEnumerable<BankDTO>>> GetBanksAsync();
    Task<GenericResponse<BankDTO>> GetBankByCodeAsync(short code);
}
