using BrasilAPI.BrasilApi;
using BrasilAPI.BrasilApi.Interfaces;
using BrasilAPI.Services;
using BrasilAPI.Services.Interfaces;

namespace BrasilAPI.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<IDDDService, DDDService>();
        services.AddScoped<IISBNService, ISBNService>();
        services.AddScoped<IPIXService, PIXService>();
        services.AddScoped<IFeeService, FeeService>();


        services.AddScoped<IBrasilApiAddress, BrasilApiAddress>();
        services.AddScoped<IBrasilApiBank, BrasilApiBank>();
        services.AddScoped<IBrasilApiDDD, BrasilApiDDD>();
        services.AddScoped<IBrasilApiISBN, BrasilApiISBN>();
        services.AddScoped<IBrasilApiPIX, BrasilApiPIX>();
        services.AddScoped<IBrasilApiFee, BrasilApiFee>();

        return services;
    }
}
