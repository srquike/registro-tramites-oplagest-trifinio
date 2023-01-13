using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class FormularioTramiteDTO
    {
        #region Propiedades necesarias para realizar un nuevo trámite
        public int TramiteId { get; set; }

        [Required]
        public string? Expediente { get; set; }

        [Required]
        public int? InmuebleId { get; set; }

        [Required]
        public int? InstructivoId { get; set; }

        public DateOnly FechaIngreso { get; set; }
        public DateOnly? FechaEgreso { get; set; }
        #endregion

        public string? Estado { get; set; }
        public string? Receptor { get; set; }
        public string? CorreoElectronicoReceptor { get; set; }
    }
}