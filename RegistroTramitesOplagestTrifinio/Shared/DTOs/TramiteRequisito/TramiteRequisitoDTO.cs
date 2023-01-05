namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.TramiteRequisito
{
    public class TramiteRequisitoDTO
    {
        public int? TramiteRequisitoId { get; set; }
        public bool Entregado { get; set; }
        public int? TramiteId { get; set; }
        public string? Nombre { get; set; }
        public int? RequistoId { get; set; }
        public string? Categoria { get; set; }
    }
}