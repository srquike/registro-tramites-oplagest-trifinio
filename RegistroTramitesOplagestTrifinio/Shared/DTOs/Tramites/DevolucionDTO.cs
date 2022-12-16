using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DevolucionDTO
    {
        public int DevolucionId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string? Motivo { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string? Comentarios { get; set; }

        public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public int? TramiteId { get; set; }
    }
}
