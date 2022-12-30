namespace RegistroTramitesOplagestTrifinio.Models;

public partial class TramiteModel
{
    public int TramiteId { get; set; }
    public string? Expediente { get; set; }
    public string? Proyecto { get; set; }
    public string? Propietario { get; set; }
    public string? Telefono { get; set; }
    public string? TipoTramite { get; set; }
    public string? TipoConstruccion { get; set; }
    public string? TipoProyecto { get; set; }
    public string? Receptor { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public DateOnly? FechaEgreso { get; set; }
    public string? ArchivadoDesde { get; set; }
    public string? Estado { get; set; }
    public int? InstructivoId { get; set; }
    public int? DireccionId { get; set; }
    public virtual InstructivoModel? Instructivo { get; set; }
    public virtual DireccionModel? Direccion { get; set; }
    public virtual ICollection<VisitaModel> Visitas { get; } = new List<VisitaModel>();
    public virtual ICollection<TramiteRequisitoModel> TramitesRequisitos { get; set; } = new List<TramiteRequisitoModel>();
    public virtual ICollection<DevolucionModel> Devoluciones { get; } = new List<DevolucionModel>();
}
