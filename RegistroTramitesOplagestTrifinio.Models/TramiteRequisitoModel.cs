namespace RegistroTramitesOplagestTrifinio.Models
{
    public class TramiteRequisitoModel
    {
        public int? TramiteRequisitoId { get; set; }
        public bool? Entregado { get; set; }
        public bool? Adicional { get; set; }
        public int? TramiteId { get; set; }
        public int? RequistoId { get; set; }
        public TramiteModel? Tramite { get; set; }
        public RequisitoModel? Requisito { get; set; }
    }
}
