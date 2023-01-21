using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public virtual string? Direccion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public virtual int? MunicipioId { get; set; }
    }
}