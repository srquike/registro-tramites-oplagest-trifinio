namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito
{
    public class TramiteRequisitoDTO
    {
        public int? TramiteRequisitoId { get; set; }
        public bool Entregado { get; set; }
        public int? TramiteId { get; set; }
        public int? RequisitoId { get; set; }
        public string? Nombre { get; set; }
    }
}