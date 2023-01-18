using Microsoft.AspNetCore.Identity;

namespace RegistroTramitesOplagestTrifinio.Models
{
    public class RolModel : IdentityRole<string>
    {
        // Propiedades de navegación
        public virtual List<UsuarioRolModel>? UsuariosRoles { get; set; }
    }
}