using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioIngresarDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string? CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }
    }
}
