using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RegistroTramitesOplagestTrifinio.Client.Authorization
{
    public class AutenticacionProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimo = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Jonathan Vanegas"),
                new Claim(ClaimTypes.Role, "Administrador")
            }, "Prueba");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimo)));
        }
    }
}
