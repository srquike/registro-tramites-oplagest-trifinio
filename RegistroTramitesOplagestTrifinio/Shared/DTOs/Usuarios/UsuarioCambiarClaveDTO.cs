using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioCambiarClaveDTO
    {
        public string? UsuarioId { get; set; }

        [Required(ErrorMessage = "Contraseña vacía no permitida")]
        [MinLength(8, ErrorMessage = "La contraseña debe contener mínimo 8 caracteres")]
        public string? Clave { get; set; }
    }
}
