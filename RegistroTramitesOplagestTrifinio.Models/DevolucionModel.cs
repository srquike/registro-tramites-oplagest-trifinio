namespace RegistroTramitesOplagestTrifinio.Models
{
    public class DevolucionModel
    {
        public int DevolucionId { get; set; }
        public string? Motivo { get; set; }
        public string? Comentarios { get; set; }
        public string? CorreoElectronicoResponsable { get; set; }
        public DateOnly Fecha { get; set; }
        public int? TramiteId { get; set; }
        public virtual TramiteModel? Tramite { get; set; }
    }
}
