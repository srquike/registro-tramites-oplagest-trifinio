namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }
        public string? Direccion { get; set; }
        public MunicipioDTO? Municipio { get; set; }
    }
}