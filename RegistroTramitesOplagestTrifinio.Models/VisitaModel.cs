namespace RegistroTramitesOplagestTrifinio.Models;

public partial class VisitaModel
{
    public int VisitaId { get; set; }
    public DateOnly? Fecha { get; set; }
    public TimeOnly? Hora { get; set; }
    public string? Encargado { get; set; }
    public string? Estado { get; set; }
    public int? TramiteId { get; set; }
    public virtual TramiteModel? Tramite { get; set; }
}
