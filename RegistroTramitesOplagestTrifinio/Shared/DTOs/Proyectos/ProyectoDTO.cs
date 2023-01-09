using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos
{
    public class ProyectoDTO
    {
        [Required]
        public int? ProyectoId { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public PersonaDTO Encargado { get; set; } = new();
    }
}
