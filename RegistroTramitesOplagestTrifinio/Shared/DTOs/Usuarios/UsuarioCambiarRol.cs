using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioCambiarRol
    {
        public string? UsuarioId { get; set; }
        [Required] public string? Rol { get; set; }
    }
}
