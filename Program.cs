using System.Text.Json.Serialization;
using BrasilAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers()
        .AddJsonOptions(opts =>
            opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

    builder.Services.AddHttpClient("BrasilAPI", httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://brasilapi.com.br");
    });

    builder.Services.AddDependencyInjection();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}