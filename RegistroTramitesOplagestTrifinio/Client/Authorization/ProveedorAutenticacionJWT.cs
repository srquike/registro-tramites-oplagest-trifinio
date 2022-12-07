using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RegistroTramitesOplagestTrifinio.Client.Herramientas;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Text.Json;
using RegistroTramitesOplagestTrifinio.Client.Authorization.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Client.Authorization
{
    public class ProveedorAutenticacionJWT : AuthenticationStateProvider, ISesionService
    {
        private readonly IJSRuntime _js;
        private readonly HttpClient _http;
        private const string _TOKEN_KEY = "TOKEN_KEY";
        private AuthenticationState Anonimo => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public ProveedorAutenticacionJWT(IJSRuntime js, HttpClient http)
        {
            _js = js;
            _http = http;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.GetFromLocalStorage(_TOKEN_KEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonimo;
            }

            return Autenticar(token);
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

        public async Task Ingresar(string token)
        {
            await _js.SetInLocalStorage(_TOKEN_KEY, token);
            var autenticacion = Autenticar(token);

            NotifyAuthenticationStateChanged(Task.FromResult(autenticacion));
        }

        public async Task Cerrar()
        {
            await _js.RemoveFromLocalStorage(_TOKEN_KEY);

            _http.DefaultRequestHeaders.Authorization = null;

            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }
    }
}
