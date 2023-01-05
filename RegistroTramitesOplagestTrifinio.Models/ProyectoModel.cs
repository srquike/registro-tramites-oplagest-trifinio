namespace RegistroTramitesOplagestTrifinio.Models
{
    public class ProyectoModel
    {
        public int ProyectoId { get; set; }
        public string? Nombre { get; set; }
        public int? EncargadoId { get; set; }

        public virtual PersonaModel? Encargado { get; set; }

        public virtual List<TramiteModel>? Tramites { get; set; }
    }
}