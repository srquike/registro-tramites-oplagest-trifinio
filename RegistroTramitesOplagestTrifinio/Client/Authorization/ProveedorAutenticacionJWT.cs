using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RegistroTramitesOplagestTrifinio.Client.Herramientas;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Text.Json;
using RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios;
using System.Linq;

namespace RegistroTramitesOplagestTrifinio.Client.Authorization
{
    public class ProveedorAutenticacionJWT : AuthenticationStateProvider, ISesionService
    {
        private readonly IJSRuntime _js;
        private readonly IPeticionesHttp _peticiones;
        private readonly IMostrarMensaje _mensaje;
        private readonly HttpClient _http;
        private const string _TOKEN_KEY = "TOKEN_KEY";
        private const string _EXPIRATION_TOKEN_KEY = "EXPIRATION_TOKEN_KEY";

        private AuthenticationState Anonimo => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public ProveedorAutenticacionJWT(IJSRuntime js, HttpClient http, IPeticionesHttp peticiones, IMostrarMensaje mensaje)
        {
            _js = js;
            _http = http;
            _peticiones = peticiones;
            _mensaje = mensaje;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.GetFromLocalStorage(_TOKEN_KEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonimo;
            }

            var expiracion = await _js.GetFromLocalStorage(_EXPIRATION_TOKEN_KEY);

            if (DateTime.TryParse(expiracion, out DateTime tiempo))
            {
                if (TiempoTokenExpirado(tiempo))
                {
                    await LimpiarLocalStorage();
                    return Anonimo;
                }

                if (RenovacionTiempoToken(tiempo))
                {
                    token = await RenovarTiempoToken(token);
                }
            }

            return Autenticar(token);
        }

        private async Task<string> RenovarTiempoToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var peticion = await _peticiones.Get<UsuarioTokenDTO>("api/cuentas/renovar");
            var nuevoToken = new UsuarioTokenDTO();

            if (peticion.Error)
            {
                await _mensaje.Error("No fue posible renovar el token");
            }
            else
            {
                nuevoToken = peticion.Respuesta;

                await _js.SetInLocalStorage(_TOKEN_KEY, nuevoToken.Token);
                await _js.SetInLocalStorage(_EXPIRATION_TOKEN_KEY, nuevoToken.Expiration.ToString());
            }

            return nuevoToken.Token;
        }

        private bool TiempoTokenExpirado(DateTime tiempo)
        {
            return tiempo <= DateTime.UtcNow;
        }

        private bool RenovacionTiempoToken(DateTime tiempo)
        {
            return tiempo.Subtract(DateTime.UtcNow) < TimeSpan.FromMinutes(5);
        }

        private async Task LimpiarLocalStorage()
        {
            await _js.RemoveFromLocalStorage(_TOKEN_KEY);
            await _js.RemoveFromLocalStorage(_EXPIRATION_TOKEN_KEY);

            _http.DefaultRequestHeaders.Authorization = null;
        }

        private AuthenticationState Autenticar(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task Ingresar(UsuarioTokenDTO token)
        {
            await _js.SetInLocalStorage(_TOKEN_KEY, token.Token);
            await _js.SetInLocalStorage(_EXPIRATION_TOKEN_KEY, token.Expiration.ToString());

            var autenticacion = Autenticar(token.Token);

            NotifyAuthenticationStateChanged(Task.FromResult(autenticacion));
        }

        public async Task Cerrar()
        {
            await LimpiarLocalStorage();
            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }

        public async Task TokenRenovatorManagement()
        {
            var expiracion = await _js.GetFromLocalStorage(_EXPIRATION_TOKEN_KEY);

            if (DateTime.TryParse(expiracion, out DateTime tiempo))
            {
                if (TiempoTokenExpirado(tiempo))
                {
                    await Cerrar();
                }

                if (RenovacionTiempoToken(tiempo))
                {
                    var token = await _js.GetFromLocalStorage(_TOKEN_KEY);
                    var nuevoToken = await RenovarTiempoToken(token);
                    var autenticacion = Autenticar(nuevoToken);

                    NotifyAuthenticationStateChanged(Task.FromResult(autenticacion));
                }

            }
        }
    }
}