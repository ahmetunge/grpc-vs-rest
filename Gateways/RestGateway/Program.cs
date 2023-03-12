using Microsoft.Net.Http.Headers;
using RestGateway.Proxies.AssetApi;
using RestGateway.Proxies.UserApi;
using RestGateway.Proxies.WalletApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

Console.WriteLine($"UserApi url: {configuration["UserApiUrl"]}");

builder.Services.AddHttpClient<IUserApiProxy, UserApiProxy>(cfg =>
{
    cfg.BaseAddress = new Uri(configuration["UserApiUrl"]);
    cfg.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddHttpClient<IAssetApiProxy, AssetApiProxy>(cfg =>
{
    cfg.BaseAddress = new Uri(configuration["AssetApiUrl"]);
    cfg.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddHttpClient<IWalletApiProxy, WalletApiProxy>(cfg =>
{
    cfg.BaseAddress = new Uri(configuration["WalletApiUrl"]);
    cfg.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
