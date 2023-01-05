namespace RegistroTramitesOplagestTrifinio.Models
{
    public class InmuebleModel
    {
        public int InmuebleId { get; set; }
        public double? Area { get; set; }
        public int? PropietarioId { get; set; }
        public int? DireccionId { get; set; }

        public PersonaModel? Propietario { get; set; }
        public DireccionModel? Direccion { get; set; }

        public virtual List<TramiteModel>? Tramites { get; set; }
    }
}
