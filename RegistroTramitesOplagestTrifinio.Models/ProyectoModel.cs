namespace RegistroTramitesOplagestTrifinio.Models
{
    public class ProyectoModel
    {
        public int ProyectoId { get; set; }
        public string? Nombre { get; set; }

        // Claves foraneas
        public int? EncargadoId { get; set; }

        // Propiedades de navegación
        public virtual PersonaModel? Encargado { get; set; }

        public virtual List<InmuebleModel>? Inmuebles { get; set; }
    }
}