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


        services.AddScoped<IBrasilApiAddress, BrasilApiAddress>();
        services.AddScoped<IBrasilApiBank, BrasilApiBank>();
        services.AddScoped<IBrasilApiDDD, BrasilApiDDD>();

        return services;
    }
}
