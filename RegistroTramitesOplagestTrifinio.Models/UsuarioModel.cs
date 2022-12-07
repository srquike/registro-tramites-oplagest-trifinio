using Microsoft.AspNetCore.Identity;

namespace RegistroTramitesOplagestTrifinio.Models;

public partial class UsuarioModel : IdentityUser
{
    public string? Nombre { get; set; }
    public bool Activo { get; set; }
    public DateOnly Creacion { get; set; }
    public virtual ICollection<ActividadModel> Actividades { get; } = new List<ActividadModel>();
}
