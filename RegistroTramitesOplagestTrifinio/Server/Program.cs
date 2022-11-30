using RegistroTramitesOplagestTrifinio.Data.Database;
using RegistroTramitesOplagestTrifinio.Services.Implementaciones;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

AgregarServiciosPersonalizados(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

void AgregarServiciosPersonalizados(IServiceCollection services)
{
    services.AddSingleton<MongoDbContext>();
    services.AddScoped<IUsuariosService, UsuariosService>();
}