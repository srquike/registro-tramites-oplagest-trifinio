using System;
using System.Collections.Generic;

namespace RegistroTramitesOplagestTrifinio.Models;

public partial class InstructivoModel
{
    public int InstructivoId { get; set; }
    public string? Nombre { get; set; }

    public virtual ICollection<RequisitoModel> Requisitos { get; } = new List<RequisitoModel>();
    public virtual ICollection<TramiteModel> Tramites { get; } = new List<TramiteModel>();
}
