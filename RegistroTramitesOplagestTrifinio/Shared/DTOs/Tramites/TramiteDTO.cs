using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class TramiteDTO
    {
        // Datos necesarios en revisar trámite nuevo
        public int? TramiteId { get; set; }
        public string? Expediente { get; set; }
        public string? Instructivo { get; set; }
        public string? Encargado { get; set; }
        public string? Propietario { get; set; }
        public string? Proyecto { get; set; }
        public string? EncargadoTelefono { get; set; }
        public string? InmuebleDireccion { get; set; }
        public string? PropietarioDireccion { get; set; }
        public string? PropietarioTelefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaEgreso { get; set; }
        public string? Receptor { get; set; }
    }
}