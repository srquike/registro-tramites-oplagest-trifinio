using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas
{
    public class VisitaDTO
    {
        public int VisitaId { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public DateOnly? Fecha { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public TimeOnly? Hora { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] public string? Encargado { get; set; }
        public string? Estado { get; set; }
        public string? Comentarios { get; set; }
        public int? TramiteId { get; set; }
        public FormularioTramiteDTO? Tramite { get; set; }
    }
}
