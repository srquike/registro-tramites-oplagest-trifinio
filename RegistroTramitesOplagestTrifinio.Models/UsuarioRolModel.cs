using Microsoft.AspNetCore.Identity;

namespace RegistroTramitesOplagestTrifinio.Models
{
    public class UsuarioRolModel : IdentityUserRole<string>
    {
        public override string UserId { get => base.UserId; set => base.UserId = value; }
        public override string RoleId { get => base.RoleId; set => base.RoleId = value; }

        // Propiedades de navegación
        public virtual UsuarioModel? User { get; set; }
        public virtual RolModel? Role { get; set; }
    }
}
