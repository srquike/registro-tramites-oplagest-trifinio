using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioCambiarRol
    {
        public string? UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo requerido")] 
        public string? Rol { get; set; }
    }
}
