using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos
{
    public class ProyectoDTO
    {
        public int ProyectoId { get; set; }
        public string? Nombre { get; set; }

        public PersonaDTO? Encargado { get; set; } = new();
    }
}
