using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioFormularioDTO
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo electr&oacutenico es requerido.")]
        public string? CorreoElectronico { get; set; }
        [Required(ErrorMessage = "La clave es requeridad.")]
        public string? Clave { get; set; }
        public bool Activo { get; set; }
    }
}
