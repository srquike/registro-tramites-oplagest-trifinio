using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Visitas;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class FormularioTramiteDTO
    {
        public int TramiteId { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] 
        public string? Proyecto { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] 
        public string? Propietario { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] 
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Campo requerido.")] 
        public string? Expediente { get; set; }
        public DireccionDTO? Direccion { get; set; }
        public string? Estado { get; set; }
        public string? Receptor { get; set; }
        public int? InstructivoId { get; set; }
        public string? Instructivo { get; set; }
        public ICollection<TramiteRequisitoDTO> TramitesRequisitos { get; set; } = new List<TramiteRequisitoDTO>();
        public ICollection<VisitaDTO> Visitas { get; set; } = new List<VisitaDTO>();
    }
}