namespace RegistroTramitesOplagestTrifinio.Shared.DTOs
{
    public class PaginacionDTO
    {
        public PaginacionDTO()
        {

        }

        public int Pagina { get; set; } = 1;
        public int Cantidad { get; set; } = 20;
    }
}
