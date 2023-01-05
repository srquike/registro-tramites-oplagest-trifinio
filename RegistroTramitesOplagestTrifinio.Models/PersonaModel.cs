namespace RegistroTramitesOplagestTrifinio.Models
{
    public class PersonaModel
    {
        public int PersonaId { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public int? DireccionId { get; set; }

        public virtual DireccionModel? Direccion { get; set; }

        public virtual List<InmuebleModel>? Inmuebles { get; set; }
        public virtual List<ProyectoModel>? Proyectos { get; set; }          
    }
}
