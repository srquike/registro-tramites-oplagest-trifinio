namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class TramiteListaDTO
    {
        public int TramiteId { get; set; }
        public string? Proyecto { get; set; }
        public string? Propietario { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public string? Receptor { get; set; }
        public string? Estado { get; set; }
        public string? ArchivadoDesde { get; set; }
        public string? Expediente { get; set; }
    }
}
