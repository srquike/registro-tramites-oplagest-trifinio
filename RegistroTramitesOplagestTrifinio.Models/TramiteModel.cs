namespace RegistroTramitesOplagestTrifinio.Models;

public partial class TramiteModel
{
    public int TramiteId { get; set; }
    public string? Expediente { get; set; }
    public string? Receptor { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public DateOnly? FechaEgreso { get; set; }
    public string? ArchivadoDesde { get; set; }
    public string? Estado { get; set; }

    public int? InstructivoId { get; set; }
    public int? ProyectoId { get; set; }
    public int? InmuebleId { get; set; }

    // Propiedades de navegación
    public virtual InstructivoModel? Instructivo { get; set; }
    public virtual ProyectoModel? Proyecto { get; set; }
    public virtual InmuebleModel? Inmueble { get; set; }

    public virtual ICollection<VisitaModel> Visitas { get; } = new List<VisitaModel>();
    public virtual ICollection<TramiteRequisitoModel> TramitesRequisitos { get; set; } = new List<TramiteRequisitoModel>();
    public virtual ICollection<DevolucionModel> Devoluciones { get; } = new List<DevolucionModel>();
}