using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        [RegularExpression(@"^((?!0)[0-9]+)$")]
        public int MunicipioId { get; set; } = 0;
    }
}