namespace RegistroTramitesOplagestTrifinio.Models;

public partial class TramiteModel
{
    public int TramiteId { get; set; }
    public string? Proyecto { get; set; }
    public string? Propietario { get; set; }
    public string? Telefono { get; set; }
    public string? Municipio { get; set; }
    public string? Departamento { get; set; }
    public string? Direccion { get; set; }
    public string? TipoTramite { get; set; }
    public string? TipoConstruccion { get; set; }
    public string? TipoProyecto { get; set; }
    public string? Receptor { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public DateOnly? FechaEgreso { get; set; }
    public string? ArchivadoDesde { get; set; }
    public string? MotivoDevolucion { get; set; }
    public string? Estado { get; set; }
    public int? InstructivoId { get; set; }
    public virtual InstructivoModel? Instructivo { get; set; }
    public virtual ICollection<VisitaModel> Visitas { get; } = new List<VisitaModel>();
    public virtual ICollection<TramiteRequisitoModel> TramitesRequisitos { get; } = new List<TramiteRequisitoModel>();
}
