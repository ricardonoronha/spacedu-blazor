using Blazored.LocalStorage;
using BlazorLoginSocial.Client;
using BlazorLoginSocial.Client.Repositories;
using BlazorLoginSocial.Client.States;
using BlazorLoginSocial.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddScoped<ICustomerRepository, CustomerHttpRepsitory>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CurrentCustomerState>();

builder.Services.AddSingleton((_) =>
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5160")
    };
    return client;
});

await builder.Build().RunAsync();
