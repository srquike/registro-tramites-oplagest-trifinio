namespace RegistroTramitesOplagestTrifinio.Models;

public partial class RequisitoModel
{
    public int RequesitoId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int? InstructivoId { get; set; }
    public int? CategoriaId { get; set; }
    public CategoriaModel? Categoria { get; set; }
    public virtual InstructivoModel? Instructivo { get; set; }
    public virtual ICollection<TramiteRequisitoModel> TramitesRequisitos { get; } = new List<TramiteRequisitoModel>();
}
