using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos
{
    public class ProyectoDTO
    {
        public int? ProyectoId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Encargado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo requerido")]
        public string Telefono { get; set; } = string.Empty;

        public string? CorreoElectronico { get; set; }
    }
}
