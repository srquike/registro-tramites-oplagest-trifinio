using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios
{
    public class UsuarioFormularioDTO
    {
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public string? CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public string? Clave { get; set; }
        public bool Activo { get; set; }
    }
}
