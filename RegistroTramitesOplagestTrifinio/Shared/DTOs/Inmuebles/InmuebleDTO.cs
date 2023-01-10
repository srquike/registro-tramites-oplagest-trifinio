using RegistroTramitesOplagestTrifinio.Shared.DTOs.Personas;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Proyectos;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites;
using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Inmuebles
{
    public class InmuebleDTO
    {
        public int? InmuebleId { get; set; }
        public double? Area { get; set; }

        [Required]
        public int? ProyectoId { get; set; }

        public DireccionDTO Direccion { get; set; } = new();
        public PersonaDTO Propietario { get; set; } = new();
    }
}
