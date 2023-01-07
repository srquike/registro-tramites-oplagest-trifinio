using RegistroTramitesOplagestTrifinio.Shared.DTOs.Instructivos;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos
{
    public class RequisitoDTO
    {
        public int RequisitoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        //public CategoriaDTO Categoria { get; set; } = new();
    }
}
