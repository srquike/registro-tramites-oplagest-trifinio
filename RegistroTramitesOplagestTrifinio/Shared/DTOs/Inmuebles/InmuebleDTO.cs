using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles
{
    public class InmuebleDTO
    {
        public int? InmuebleId { get; set; }

        public DireccionDTO Direccion { get; set; } = new();
        public PersonaDTO Propietario { get; set; } = new();

    }
}
