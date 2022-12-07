using System;
using System.Collections.Generic;

namespace RegistroTramitesOplagestTrifinio.Models;

public partial class VisitaModel
{
    public int VisitaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Encargado { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<TramiteModel> Tramites { get; } = new List<TramiteModel>();
}
