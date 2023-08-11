using BrasilAPI.Models;
using BrasilAPI.Response;

namespace BrasilAPI.BrasilApi.Interfaces;

public interface IBrasilApiBank
{
    Task<GenericResponse<IEnumerable<Bank>>> GetBanksAsync();
    Task<GenericResponse<Bank>> GetBankByCodeAsync(short code);
}
