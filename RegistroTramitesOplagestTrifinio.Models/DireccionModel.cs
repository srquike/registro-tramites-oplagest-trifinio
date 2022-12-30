namespace RegistroTramitesOplagestTrifinio.Models
{
    public class DireccionModel
    {
        public int DireccionId { get; set; }
        public string? Direccion { get; set; }
        public int? MunicipioId { get; set; }

        // Propiedades de navegación
        public virtual MunicipioModel? Municipio { get; set; }
        public virtual ICollection<TramiteModel>? Tramites { get; } = new List<TramiteModel>();
    }
}