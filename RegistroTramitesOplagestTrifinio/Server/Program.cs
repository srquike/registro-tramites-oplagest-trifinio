using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegistroTramitesOplagestTrifinio.Data;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Server.Herramientas;
using RegistroTramitesOplagestTrifinio.Server.Workers;
using RegistroTramitesOplagestTrifinio.Services;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OplagestDb")));
builder.Services.AddIdentity<UsuarioModel, RolModel>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireUppercase = false;
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
        ClockSkew = TimeSpan.Zero
    });

// Servicios personalizados
builder.Services.AddScoped<ITramitesService, TramitesService>();
builder.Services.AddScoped<IRequisitosService, RequisitosService>();
builder.Services.AddScoped<IInstructivosService, InstructivosService>();
builder.Services.AddScoped<IVisitasService, VisitasService>();
builder.Services.AddScoped<IDevolucionesService, DevolucionService>();
builder.Services.AddScoped<ITramitesRequisitosService, TramitesRequisitosService>();
builder.Services.AddScoped<IActividadesService, ActividadesService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IInmueblesService, InmueblesService>();
builder.Services.AddScoped<IPersonasService, PersonasService>();
builder.Services.AddScoped<IDireccionesService, DireccionesService>();
builder.Services.AddScoped<IAlertas, Alertas>();

// builder.Services.AddHostedService<NotificarAlertasCorreoElectronicoWorker>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
