using RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class TramiteDTO
    {
        // Datos necesarios en revisar trámite nuevo
        public int? TramiteId { get; set; }
        public string? Expediente { get; set; }
        public string? Instructivo { get; set; }
        public string? Propietario { get; set; }
        public string? Proyecto { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}