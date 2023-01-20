using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioCambiarClaveDTO
    {
        public string? UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo requerido######")]
        public string? Clave { get; set; }
    }
}
