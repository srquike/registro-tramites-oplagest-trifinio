using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistroTramitesOplagestTrifinio.Client;
using RegistroTramitesOplagestTrifinio.Client.Authorization;
using RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces;
using RegistroTramitesOplagestTrifinio.Client.Herramientas;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPeticionesHttp, PeticionesHttp>();
builder.Services.AddScoped<IMostrarMensaje, MostrarMensaje>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(provider =>
    provider.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ISesionService, ProveedorAutenticacionJWT>(provider =>
    provider.GetRequiredService<ProveedorAutenticacionJWT>());

await builder.Build().RunAsync();
