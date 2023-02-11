namespace RegistroTramitesOplagestTrifinio.Models
{
    public class DireccionModel
    {
        public int DireccionId { get; set; }
        public string? Direccion { get; set; }
        public int? MunicipioId { get; set; }

        // Propiedades de navegación
        public virtual MunicipioModel? Municipio { get; set; }

        //public virtual List<InmuebleModel>? Inmuebles { get; set; }
        //public virtual List<PersonaModel>? Personas { get; set; }
    }
}