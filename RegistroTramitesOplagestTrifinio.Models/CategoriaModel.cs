namespace RegistroTramitesOplagestTrifinio.Models
{
    public class CategoriaModel
    {
        public int CategoriaId { get; set; }
        public string? Nombre { get; set; }
        public virtual ICollection<RequisitoModel> Requisitos { get; } = new List<RequisitoModel>();
    }
}
