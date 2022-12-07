using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioIngresarDTO
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string? CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string? Clave { get; set; }
    }
}
