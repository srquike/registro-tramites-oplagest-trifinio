using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas
{
    public class PersonaDTO
    {
        public int? PersonaId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo requerido")]
        public string Telefono { get; set; } = string.Empty;

        public int? DireccionId { get; set; }
        public string? CorreoElectronico { get; set; }
        public DireccionDTO Direccion { get; set; } = new();
    }
}
