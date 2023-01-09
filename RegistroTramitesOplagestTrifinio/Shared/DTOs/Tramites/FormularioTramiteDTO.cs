using RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;
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
        public int? ProyectoId { get; set; }

        [Required]
        public int? InstructivoId { get; set; }
        #endregion

        public InmuebleDTO? Inmueble { get; set; } = new();

        public string? Estado { get; set; }
        public string? Receptor { get; set; }
    }
}