using System;
using System.Collections.Generic;

namespace RegistroTramitesOplagestTrifinio.Models;

public partial class RequisitoModel
{
    public int RequesitoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Adicional { get; set; }

    public string? Descripcion { get; set; }

    public int? InstructivoId { get; set; }

    public virtual InstructivoModel? Instructivo { get; set; }
}
