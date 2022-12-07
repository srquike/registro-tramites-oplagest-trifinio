namespace RegistroTramitesOplagestTrifinio.Models;

public partial class ActividadModel
{
    public int ActividadId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Resumen { get; set; }
    public string? UsuarioId { get; set; }

    public virtual UsuarioModel? Usuario { get; set; }
}
