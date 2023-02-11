namespace RegistroTramitesOplagestTrifinio.Models
{
    public class InmuebleModel
    {
        public int InmuebleId { get; set; }
        public double? Area { get; set; }
        public string? Direccion { get; set; }

        // Claves foraneas
        public int? PropietarioId { get; set; }
        //public int? DireccionId { get; set; }
        public int? ProyectoId { get; set; }

        // Propiedades de navegación
        public PersonaModel? Propietario { get; set; }
        //public DireccionModel? Direccion { get; set; }
        public ProyectoModel? Proyecto { get; set; }

        public virtual List<TramiteModel>? Tramites { get; set; }
    }
}
