using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        public int? MunicipioId { get; set; }
    }
}