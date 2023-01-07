using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas
{
    public class PersonaDTO
    {
        public int? PersonaId { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        public string? CorreoElectronico { get; set; }

    }
}
