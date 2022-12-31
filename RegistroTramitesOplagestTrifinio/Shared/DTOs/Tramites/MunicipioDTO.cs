using System.ComponentModel.DataAnnotations;

namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Tramites
{
    public class MunicipioDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int MunicipioId { get; set; }
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? DepartamentoId { get; set; }
    }
}
