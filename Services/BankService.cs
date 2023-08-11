using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.DTOs;
using BrasilAPI.Response;
using BrasilAPI.Services.Interfaces;
using Mapster;

namespace BrasilAPI.Services;

public class BankService : IBankService
{
    private readonly IBrasilApiBank _brasilApiBank;

    public BankService(IBrasilApiBank brasilApiBank)
    {
        _brasilApiBank = brasilApiBank;
    }

    public async Task<GenericResponse<IEnumerable<BankDTO>>> GetBanksAsync()
    {
        var banks = await _brasilApiBank.GetBanksAsync();

        return banks.Adapt<GenericResponse<IEnumerable<BankDTO>>>();
    }

    public async Task<GenericResponse<BankDTO>> GetBankByCodeAsync(short code)
    {
        var bank = await _brasilApiBank.GetBankByCodeAsync(code);

        return bank.Adapt<GenericResponse<BankDTO>>();
    }
}
